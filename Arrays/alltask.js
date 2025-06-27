// Alltask

/* Task 1 */

// function getSpecialNumbers(array) {
//     if(!Array.isArray(array)) return null;
//     return array.filter(n => n % 3 === 0);
// }

// const arr = [1,9,8,6,18];

// console.log(getSpecialNumbers(arr))
// console.log(arr);

/* Task 2 */

// function sortDesc(array) {
//     if(!Array.isArray(array)) return null;

//     return array.toSorted((a,b) => b-a);
// }


// const arr = [1,9,8,6,18];
// console.log(sortDesc(arr));
// console.log(arr);

/* Task 3 */

// function flatArray(array) {
//     if(!Array.isArray(array)) return null;

//     return array.flat();
// }

// const arr = [1,9,[1,5,9],6,18];
// console.log(flatArray(arr));
// console.log(arr)

/* Task 4 */

// const getMessagesForBestStudents = () => allMembers.filter(student => !losers.includes(student)).map(name => `Good job, ${name}`);

// const allMembers = ['Tom', 'Liza', 'Ali', 'Nina'];
// const losers = ['Tom','Nina'];

// console.log(getMessagesForBestStudents(allMembers,losers));

/* Task 5 */

/* 1 */

// function simpleNum(num) {
//     if(num < 2) return false;

//     for (let i = 2; i < Math.sqrt(num); i++) {
//         if(num % i === 0) return false;
//     }

//     return true;
// }

// function isPrime(array) {
//     return array.filter(simpleNum);
// }

// const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 17];

// console.log(isPrime(numbers));

/* 2 */

// const matrix = [
//     [1, 2],
//     [3, 4],
//     [5, 6]
//   ];


// const transpose = (matrix) => matrix[0].map((_, colIndex) => matrix.map(row => row[colIndex]));

// console.log(transpose(matrix));


/* 3 */

// const array = [1,1,5,8,6,7,5,1];

// const double = (array) => array.filter((item, index) => array.indexOf(item) === index);

// console.log(double(array));

/* 4 */

// function groupByFirstLetter(names) {
//   return names.reduce((acc, name) => {
//     const firstLetter = name[0].toUpperCase();
//     if (!acc[firstLetter]) {
//       acc[firstLetter] = [];
//     }
//     acc[firstLetter].push(name);
//     return acc;
//   }, {});
// }

// const students = ['Anna', 'Tom', 'Alice', 'Bob', 'Tim'];

// console.log(groupByFirstLetter(students));


/* 5 */

// function frequentNumber(array) {
//     if (!Array.isArray(array) || array.length === 0) return null;
  
//     const counts = array.reduce((acc, num) => {
//       acc[num] = (acc[num] || 0) + 1;
//       return acc;
//     }, {});
  
//     let maxCount = 0;
//     let mostFrequent = null;
  
//     for (const num in counts) {
//       if (counts[num] > maxCount) {
//         maxCount = counts[num];
//         mostFrequent = Number(num);
//       }
//     }
  
//     return { value: mostFrequent, count: maxCount };
//   }
  
// const numbers = [1, 3, 3, 7, 1, 3, 2, 2, 2, 2, 4];
// console.log(frequentNumber(numbers)); 
  
/* 6 */

// function square(array) {
//     return array
//       .filter(num => num % 2 !== 0)   
//       .map(num => num ** 2);          
//   }
  
// const nums = [1, 2, 3, 4, 5, 6];
// console.log(square(nums));  
  

/* 7 */


// function divide(array, size) {
//     const result = [];
  
//     for (let i = 0; i < array.length; i += size) {
//       result.push(array.slice(i, i + size));
//     }
  
//     return result;
//   }
  
// const array = [1, 3, 3, 7, 1, 3, 2, 2, 2, 2, 4];
// console.log(divide(array, 3)); 

/* 8 */

// const checkIsString = (array) => array.every(element => typeof element === 'string');

// const arr1 = ['apple', 'banana', 'orange'];
// const arr2 = ['apple', 42, 'orange'];

// console.log(checkIsString(arr1)); 
// console.log(checkIsString(arr2)); 

/* 9 */

// const students = ['Anna', 'Tom', 'Alice', 'Bob', 'Tim'];

// function formatingOfNames(students) {
//     let studentsNames = "Students: ";
//     return studentsNames + students.join(", ");
// }

// console.log(formatingOfNames(students));

/* 10 */

// const array = [1, 3, 3, 7, 1, 3, 2, 2, 2, 2, 4];

// const average = (array) => array.reduce((acc, val)=> acc + val, 0)/array.length;

// console.log(average(array));