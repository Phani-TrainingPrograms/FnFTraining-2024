const os = require('os');
console.log(os.userInfo());
console.log(os.hostname());
console.log(os.arch())
console.log(os.platform());
console.log(os.version());
console.log("The Uptime of the Os: " + os.uptime()/3600 + "hrs");
console.log("The total Cpus with my machine is " + os.cpus().length)
console.log("The Total memory: " + os.totalmem());