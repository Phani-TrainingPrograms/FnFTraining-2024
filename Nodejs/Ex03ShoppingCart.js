const shoppingCart = require('./CartIIFE');

shoppingCart.addItem({"id" : 123, "itemName" : "Apples", "price" : 345});
shoppingCart.addItem({"id" : 123, "itemName" : "Apples", "price" : 345});
shoppingCart.addItem({"id" : 123, "itemName" : "Apples", "price" : 345});
shoppingCart.addItem({"id" : 123, "itemName" : "Apples", "price" : 345});
shoppingCart.addItem({"id" : 123, "itemName" : "Apples", "price" : 345});

const items = shoppingCart.getAll();

for (const item of items) {
    console.log(item);
}