/* Task 1 */

// function getArrayBounds (array){
//     if(!Array.isArray(array)) return null;

//     return [array.length,array[0],array[array.length-1]];
// }

// let arr = [1,2,3];
// let arr2 = 5;

// console.log(getArrayBounds(arr));
// console.log(getArrayBounds(arr2));

/* Task 2 */


// function getSum(array) {
//     let sum = 0;

//     if(!Array.isArray(array)) return null;

//     for (const i of array){
//         if (typeof i !== 'number') return null;
//         sum+=i;
//     }

//     return sum;
// }

// let arr = [1,2,3];
// let arr2 = 5;
// let arr3 = [1,1,1,"a",8];

// console.log(getSum(arr));
// console.log(getSum(arr2));
// console.log(getSum(arr3));

/* Task 3 */

// function getSpecialNumbers(num1,num2) {
//     let specialArray = [];

//     for(let i=num1; i<=num2; i++){
//         if(i%3 == 0) specialArray.push(i);
//     }

//     return specialArray;
// }

// console.log(getSpecialNumbers(1,9));


/* Task 4 */

// // Fisrt 
// function swap(array) {
//     if(!Array.isArray(array)) return null;

//     let newArray = [...array];
    
//     newArray.push(newArray[0]);
//     newArray.shift();
//     return newArray;
// }

// // Second
// function swap2(array){
//     if(!Array.isArray(array)) return null;

//     const [first, ...rest] = array;
//     return [...rest, first];
// }


// let arr = [1,2,3];


// console.log("Swap1");
// console.log(swap(arr));
// console.log("Swap2");
// console.log(swap2(arr));
