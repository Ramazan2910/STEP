/* Task 1 */

// function palindrome(str) {
//     let counter = str.length-1

//     for(let i = 0; i < str.length / 2; i++,counter--){
//         if(str[i] !== str[counter]) return "Not palindrome";
        
//     }
//     return "Palindrome!";
// }

// console.log(palindrome("AHAHA"));

/* Task 2 */

// function vowelsCounter(str) {
//     const vowel = ['a', 'e', 'i', 'o', 'u'];
//     let counter = 0;
    
//     for (const i of str.toLowerCase()) {
//         if(vowel.includes(i)) counter++;
//     }

//     return counter;
// }

// console.log(vowelsCounter("hahaha"));


/* Task 3 */

// const calc = (expression) => eval(expression);

// console.log(calc("2*3"));


/* Task 4 */

// function findLongestWord(sentence) {
//     if (typeof sentence !== 'string') return null;
  
//     const words = sentence.split(' ');
//     let longest = '';
  
//     for (const word of words) {
//       if (word.length > longest.length) {
//         longest = word;
//       }
//     }
  
//     return longest;
// }

// console.log(findLongestWord("JavaScript is an amazing language"));

/* Task 5 */

// function compareWords(word1,word2) {
//     if(word1.length == word2.length){
//         for(i = 0; i < word1.length; i++){
//             if(word1[i].toLowerCase() !== word2[i].toLowerCase()) return "Not same";
//         }
//         return "Same";
//     }
//     return "Not same";
// }

// console.log(compareWords("hAH","HaH"))
