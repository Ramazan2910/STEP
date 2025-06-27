// 1 
const book ={
    title: "War and peace",
    author: "Leo Tolstoy",
    year: 1867,

    // 2
    getSummary(){
        return `${this.title} by ${this.author}`
    }
}

// 3
for (const key in book) {
    console.log(`${key}: ${book[key]}`);
}

// 4
Object.entries(book).forEach((key,value) =>{
    console.log(`${key}: ${book[key]}`)
})

// 5
const updatedBook = { ...book, year: 1900 };
console.log(updatedBook);

// 6
const{title,author} = book;
console.log(title);
console.log(author);

// 7
const lineOfKeys = (obj) => Object.keys(obj).join(', ');
console.log(lineOfKeys(book));

// 8
const getStringKeys = (obj) => Object.values(obj).filter(element => typeof element == "string");
console.log(getStringKeys(book));
