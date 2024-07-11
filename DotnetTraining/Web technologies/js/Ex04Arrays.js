const fruits = ["Apples", "Mangoes", "Oranges"];
console.log(fruits);
/*
//Using for loop
for (let index = 0; index < fruits.length; index++) {
    const element = fruits[index];
    console.log(element);
}

//for..of loop is similar to foreach in C# Introduced in ES 7.
for (const element of fruits) {
    console.log(element);
}

//for..in loop uses index for iteration. key is the index.  
for (const key in fruits) {
    console.log(`Index: ${key}: Value:${fruits[key]}`)
}
console.log("ES5 syntax of foreach statement using Arrow operator(Lambda Expressions)");
fruits.forEach((element)=>{
  console.log(element);  
})

*/
///////////////////Nice features of JS Arrays////
fruits.push("Pine Apples");//Adds the element to the bottom of the List....
fruits.push("Custard Apples");
fruits.push("Ooty Apples");

fruits.unshift("Kiwi Fruit");//Adds the element to the begining of the List..
for (const element of fruits) {
    console.log(element);   
  }
console.log("Trying to add in between");  
//Splice method is used to remove, insert, replace elements within the array. 
fruits.splice(2, 1, "Gauva", "Banana", 'Pomogranete')

for (const element of fruits) {
  console.log(element);   
}


