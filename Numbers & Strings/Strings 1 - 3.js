/* Task 1 */

// function splitText(exspression, size = 10) {
//     if (typeof exspression !== 'string') return null;

//     const result = [];

//     for (let i = 0; i < exspression.length; i += size) {
//       let part = exspression.slice(i, i + size);
//       part = part[0].toUpperCase() + part.slice(1); 
//       result.push(part);
//     }
  
//     return result.join('\n'); 
// }

// console.log(splitText("hello world this is javascript", 5));

/* Task 2 */

// function sortContacts(array, flag = true) {
//   if(!Array.isArray(array)) return null;


//   return [...array].sort((a, b) =>
//     flag ? a.name.localeCompare(b.name) : b.name.localeCompare(a.name)
//   );
// }

// const contactList = [
//   { name: 'Tom', phoneNumber: '777-77-77' },
//   { name: 'Alice', phoneNumber: '123-45-67' },
//   { name: 'Bob', phoneNumber: '999-99-99' }
// ];

// console.log(sortContacts(contactList));

/* Task 3 */

// let message = "JavaScript";
// console.log(message.length)

// console.log(message[0]);

// console.log("HELLO".toLocaleLowerCase());

// console.log("programming".includes("gram"));

// console.log(" hello world ".trim());

// const toCapitalize = (str) => str[0].toUpperCase() + str.slice(1);
// console.log(toCapitalize("hello")); 

// const str = "12-34-56";
// const result = str.replaceAll('-', '_');
// console.log(result); 

// const str1 ="apple,banana,orange";
// console.log(str1.split(","));

// let name = "Azer";
// console.log(`Привет, ${name}`);

// const str2 = "JavaScript";
// const sub = str.slice(4);
// console.log(sub)




