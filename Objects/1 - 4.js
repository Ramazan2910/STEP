/* Task 1 */

// function transformToObject(array) {
//     const obj = {};
//     array.forEach(element => {
//         obj[element] = element;
//     });
//     return obj;
// }

// const array = [1, "hello", 15.5];
// console.log(transformToObject(array));

/* Task 2 */

// const concatProps = (obj) => Object.values(obj);

// const obj = { name: 'John Doe', age: 17, interest: 'football' };

// console.log(concatProps(obj));

/* Task 3 */

// const getAdults = (obj) => Object.entries(obj).filter(([name, age]) => age >= 18).map(([name]) => name);

// const obj = { 'John Doe': 19, 'Tom': 17, 'Bob': 18 };

// console.log(getAdults(obj));

/* Task 4 */

// const copyObj = (obj) => {
//     return {...obj};
// };

// const obj = { 'John Doe': 19, 'Tom': 17, 'Bob': 18 };

// console.log(copyObj(obj));