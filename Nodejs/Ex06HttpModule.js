//HttpModule is used for creating and performing http operations in Nodejs
const http = require('http');
const fs = require("fs");
const root = __dirname;//Directory of the Application(Current dir)
const portNo = 1234;

http.createServer((req, res)=>{
    const url = req.url;
    if(url != "/favicon.ico"){
        if(url == "/Welcome"){
            res.write("<h1>Hello world from Nodejs webserver</h1>");
            res.write("The requested Url was: " + url);
            res.end();
        }else if("/ClientApp"){
             const fileName = root +"/ClientApp.html";
             fs.createReadStream(fileName).pipe(res);
             return;  
        }
    }
}).listen(portNo);

console.log(`Server is available at port: ${portNo}`);