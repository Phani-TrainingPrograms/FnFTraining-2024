class Customer{
    constructor(id, name, address){
        this.CustomerId = id;
        this.CustomerName = name;
        this.CustomerAddress = address
    }
}

class CustomerRepo{
    customerData =[];
    constructor(){
        this.customerData.push(new Customer(11, "Phaniraj", "Bangalore"))
        this.customerData.push(new Customer(11, "Phaniraj", "Bangalore"))
        this.customerData.push(new Customer(11, "Phaniraj", "Bangalore"))
        this.customerData.push(new Customer(11, "Phaniraj", "Bangalore"))
    }
    addCustomer = (cst) => this.customerData.push(cst);
    
    getAll = () => this.customerData;

    findCustomer = (id) => this.customerData.find((c)=>c.CustomerId == id);

    findAllCustomers = (name) => this.customerData.filter(c => c.CustomerName.inclues(name))
}