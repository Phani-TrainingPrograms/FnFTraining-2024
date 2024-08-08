//interface is simliar to struct of C. So if U want a udt that does not have method but only data, then U can create it as an interface. 
export interface Employee {
    empId : number,
    empName : string, 
    empAddress : string, 
    empSalary : number,
    empPic : string
}
