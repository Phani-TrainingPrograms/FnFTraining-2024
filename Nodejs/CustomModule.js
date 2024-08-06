//All modules are created using a command called module.exports.
module.exports.simpleFunction = function(){
    console.log("Simple function is created");
}

module.exports.mathTable = function(num = 5){
    console.log(`Multiplication table for ${num}`);
    for(let i = 1; i <=10; i++){
        console.log(`${num} X ${i} = ${num * i}`);
    }
    console.log("-----------End of the table-------");
}

module.exports.book = class{
    constructor(id, title, price){
        this.bookId = id;
        this.title = title;
        this.price = price;
    }
}