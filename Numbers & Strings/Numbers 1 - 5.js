/* Task 1 */

// const array = [1,1.5,Infinity,NaN,"hello",null,1.84,NaN,'123a'];

// const getFiniteNumbers = (array) => array.filter(Number.isFinite);

// console.log(getFiniteNumbers(array));

// const getFiniteNumbersV2 = (array) => array.filter(isFinite);

// console.log(getFiniteNumbersV2(array));

// const getNaN = (array) => array.filter(Number.isNaN);

// console.log(getNaN(array));

// const getNaNV2 = (array) => array.filter(isNaN);

// console.log(getNaNV2(array));

// const getIntegers = (array) => array.filter(Number.isInteger);

// console.log(getIntegers(array));


/* Task 2 */

// const array = ["10", "15.5", "20px", "abc", "3.14", 42];

// const getParsedIntegers = (array) => array.map(Number.parseInt);

// console.log(getParsedIntegers(array));

// const getParsedIntegersV2 = (array) => array.map(parseInt);

// console.log(getParsedIntegersV2(array));

// const getParsedFloats = (array) => array.map(Number.parseFloat);

// console.log(getParsedFloats(array));

// const getParsedFloatsV2 = (array) => array.map(parseFloat);

// console.log(getParsedFloatsV2(array));

/* Task 3 */

// function multiRound(num) {
//     const a = 100;

//     return [
//         Math.floor(num * a) / a,
//         Math.round(num * a) / a,
//         Math.ceil(num * a) / a,
//         Math.trunc(num * a) / a,
//         Number(num.toFixed(2))
//     ];
// }

// console.log(multiRound(-3.1845))

/* Task 4 */

// function getMaxAbsoluteNumber(array) {
//     if(!Array.isArray(array) || array.length === 0) return null;

//     return Math.max(...array.map(Math.abs));
// }

// const array = [-777, 3, -1, 45, -20];
// console.log(getMaxAbsoluteNumber(array));

/* Task 5 */

// const isEqual = Math.abs(0.1 + 0.2 - 0.3) < Number.EPSILON;
// console.log(isEqual); 

// const Finite = (num) => isFinite(num);
// console.log(Finite(5));

// const maxValue = (num1,num2,num3) => Math.max(num1,num2,num3);
// console.log(maxValue(5,7,9));

// const integer = (num) => Number.isInteger(num);
// console.log(integer(5));

// const rounding = (num) => Number.parseFloat(num.toFixed(2));
// console.log(rounding(5.4846526));