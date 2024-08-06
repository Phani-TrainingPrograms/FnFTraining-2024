//FileStream module in Nodejs is used to perform IO operations on files. 
const fs = require('fs');//std modules will not have ./ 
const { cwd } = require('process');

const fileName = "./Ex04Fsmodule.js";

/////////////File Reading//////////////////////////////////
// fs.readFile(fileName, 'utf-8', (err, data)=>{
//     if(err){
//         console.log(err.message);
//     }else{
//         console.log(data);
//     }
// })
// console.log("File reading is going on.....")
///////File Reading synchronously//////////////
// const contents = fs.readFileSync(fileName, "utf-8");
// console.log(contents);
////////////////////////////////////////////////////////////////

const obj ={};
obj.id = 123; obj.name="testName"; obj.address ="testAddress";
let data = `${JSON.stringify(obj)}`;
fs.appendFileSync("SampleData.json", data, 'utf-8');
//todo: Create a Nodejs app that stores the data as CSV file. 
