//Immediately Invoked Function Expressions.
module.exports = (function(){
    let cart= [];

    function addItem(item){
        cart.push(item);
    }

    function findItem(id){
        return cart.find(i => i.id == id)
    }

    function removeItem(item){
        const index = cart.findIndex(i =>  i.id == item.id);
        if(index < 0)
         throw "Not found";
        cart.splice(index, 1);
    }

    function getAll(){
        return cart;
    }
    return{
        addItem,  findItem, removeItem, getAll   
    }
})()