/* Create a WiFi access point and provide a web server on it. */

#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>

#ifndef APSSID
#define APSSID "MiniDrone"
#define APPSK  "12345678"
#endif

/* Set these to your desired credentials. */
const char* ssid = APSSID;
const char* password = APPSK;
String ArgName = "";
String ArgValue = "";

ESP8266WebServer server(80);
const char* serverIndex = "<form method='POST' action='/updatefile' enctype='multipart/form-data'><input type='file' name='update'><input type='submit' value='Update'></form>";

void handleRoot() {
  server.send(200, "text/html", "<h1>You are connected to MiniDrone</h1>");
}

void handleCommand() {
  // Parse all the Aguments
  for (uint8_t i = 0; i < server.args(); i++) {
    ArgName = server.argName(i);
    ArgValue = server.arg(i);

    // Trim the Arguments
    ArgName.trim();
    ArgName.toUpperCase();
    ArgValue.trim();
    ArgValue.toUpperCase();
    
    if(ArgName == "COMMAND") {
      ArgValue += "\n";
      Serial.println(ArgValue);
    }
  }

 server.send(200, "text/plain", "OK");
}

void setup() {
  delay(1000);
  Serial.begin(9600);
  Serial.println();
  Serial.print("Configuring access point...");
  /* You can remove the password parameter if you want the AP to be open. */
  WiFi.softAP(ssid, password);

  IPAddress myIP = WiFi.softAPIP();
  Serial.print("AP IP address: ");
  Serial.println(myIP);
  
  server.on("/", handleRoot);
  server.on("/sendcommand", handleCommand);
  server.on("/update", HTTP_GET, []() {
     server.sendHeader("Connection", "close");
     server.send(200, "text/html", serverIndex);
  });
  server.on("/updatefile", HTTP_POST, []() {
      server.sendHeader("Connection", "close");
      server.send(200, "text/plain", (Update.hasError()) ? "FAIL" : "OK");
      ESP.restart();
    }, []() {
      HTTPUpload& upload = server.upload();
      if (upload.status == UPLOAD_FILE_START) {
        Serial.setDebugOutput(true);
        //WiFiUDP::stopAll();
        Serial.printf("Update: %s\n", upload.filename.c_str());
        uint32_t maxSketchSpace = (ESP.getFreeSketchSpace() - 0x1000) & 0xFFFFF000;
        if (!Update.begin(maxSketchSpace)) { //start with max available size
          Update.printError(Serial);
        }
      } else if (upload.status == UPLOAD_FILE_WRITE) {
        if (Update.write(upload.buf, upload.currentSize) != upload.currentSize) {
          Update.printError(Serial);
        }
      } else if (upload.status == UPLOAD_FILE_END) {
        if (Update.end(true)) { //true to set the size to the current progress
          Serial.printf("Update Success: %u\nRebooting...\n", upload.totalSize);
        } else {
          Update.printError(Serial);
        }
        Serial.setDebugOutput(false);
      }
      yield();
    });
  server.begin();

  //Print the url
  Serial.print("HTTPUpdateServer ready! Open http://");
  Serial.print(myIP);
  Serial.println("/update in your browser\n");
}

void loop() {
  server.handleClient();
}