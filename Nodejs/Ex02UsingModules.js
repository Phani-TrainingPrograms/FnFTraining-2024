//JS code in Nodejs is distributed using modules modules are self contained units that can be consumed in other js files.   

const external = require("./CustomModule");

console.log(external);
console.log(external.simpleFunction())
external.mathTable();

const myBook = new external.book(11, "2 States", 600);
console.log(myBook);