const http = require("http");
const fs = require("fs");
const parse = require("url").parse;
const empList = [];

const portNo = 1234;
const root =__dirname;
const data = require("./mydata.json");

function errorPage(res){
    const file = root + "/ErrorPage.html";
    fs.createReadStream(file).pipe(res);
}

function processGet(req, res){
  let query = parse(req.url, true).query;
  var rec = {"name" : query.username, "email" : query.useremail};
  empList.push(rec);
  const msg =`<p>Thank you for registering with us!!</p><p>Mr.${query.username}'s email Address is ${query.useremail} </p>`
  res.write(msg);
  res.end();
}

http.createServer((req, res)=>{
    console.log(req.method);
    if(req.method == "GET"){
        const query = parse(req.url).query;
        if(query != null){
        processGet(req, res);
        return;
        }
    }
    switch(req.url){
        case "/EmpList":
            res.write(JSON.stringify(empList));
            break;
        case "/EmpData":
            res.write(JSON.stringify(data));
            break;
        case "/Register":
            //create a page called Regpage.html and have inputs for Name and Email Address with a Submit button. 
            fs.createReadStream(root +"/RegistrationPage.html").pipe(res);
            return;
        default:
            errorPage(res);
            return;
    }
    res.end();
}).listen(portNo);
console.log("Server is available at port no 1234");