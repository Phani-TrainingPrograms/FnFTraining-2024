console.log("Hello world");

const addFunc = (f, s) => (f+s);

const res = addFunc(123, 23);
//Nodejes does not have inputs from the user. As most of JS code is executed on a Internet based Environment like browsers, inputs are expected to be taken in the form of Html elements. 

console.log(res);

//todo: create a array of Products and display them using for of...

const data=[
    {"id": 123, "name": "Phaniraj", "address": "Bangalore"},
    {"id": 124, "name": "Andrew", "address": "New York"},
    {"id": 125, "name": "John", "address": "Canberra"},
    {"id": 126, "name": "Tim", "address": "Sydney"},
    {"id": 127, "name": "Bill", "address": "Paris"},
    {"id": 128, "name": "Donald", "address": "London"}
]

for(const rec of data)
    console.log(rec);
