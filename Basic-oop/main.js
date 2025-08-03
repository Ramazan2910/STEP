
// /* Task 1 */

// const Student = {
//   name: "Ramazan",
//   surname: "Guliyev",
//   age: 19,
//   speciality: "ITT",
//   course: 2,
//   fullname(){
//     return this.name + ' ' + this.surname;
//   },
//   graduate_year(){
//     return new Date().getFullYear() + (4 - this.course);
//   }
// }

// console.log(Student.fullname());
// console.log(Student.graduate_year()); 

// /* Task 2 */

// const products = [
//   { name: "Laptop", price: 1200, category: "electronics", inStock: true },
//   { name: "Phone", price: 800, category: "electronics", inStock: false },
//   { name: "Table", price: 300, category: "furniture", inStock: true },
//   { name: "Book", price: 25, category: "education", inStock: true },
//   { name: "Computer", price: 1500, category: "electronics", inStock: true }
// ];

// // 1. Товары в наличии
// const availableProducts = products.filter(p => p.inStock);
// console.log("В наличии:", availableProducts);

// // 2. Цена меньше 500
// const cheapProducts = products.filter(p => p.price < 500);
// console.log("Дешёвые товары:", cheapProducts);

// // 3. Категория "electronics"
// const electronics = products.filter(p => p.category === "electronics");
// console.log("Электроника:", electronics);

// // 4. Самый дорогой товар
// const mostExpensive = products.reduce((max, p) => p.price > max.price ? p : max, products[0]);
// console.log("Самый дорогой:", mostExpensive);

// // 5. Кол-во товаров по категориям
// const categoryCount = products.reduce((acc, p) => {
//   acc[p.category] = (acc[p.category] || 0) + 1;
//   return acc;
// }, {});
// console.log("Кол-во по категориям:", categoryCount);



// /* Task 3 */

// const count1 = {
//   numberOfCount: 1,
//   nameOfOwner: "Ramazan",
//   balance: 500,
//   history: [],


//   get infoAboutCount(){
//     return `Number of count: ${this.numberOfCount}\nName of owner: ${this.nameOfOwner}\nBalance: ${this.balance}`
//   },

//   get historyOfCount(){
//     return this.history;
//   },

//   deposit(money){
//     this.history.push("Deposit");
//     return this.balance+=money;
//   },

//   withdraw(money){
//     this.history.push("Withdraw");
//     return this.balance-=money;
//   },

//   transfer(receiver, money){
//     this.history.push("Transfer");
//     receiver.history.push("Transfer")
//     this.balance-=money;
//     receiver.balance+=money;
//     return `Money successfully transferred from ${this.numberOfCount} to ${receiver.numberOfCount}!`
//   }
// }

// const count2 = {
//   numberOfCount: 2,
//   nameOfOwner: "Yegana",
//   balance: 300,
//   history: [],

//   get infoAboutCount(){
//     return `Number of count: ${this.numberOfCount}\nName of owner: ${this.nameOfOwner}\nBalance: ${this.balance}`
//   },

//   get historyOfCount(){
//     return this.history;
//   },

//   deposit(money){
//     this.history.push("Deposit");
//     return this.balance+=money;
//   },

//   withdraw(money){
//     this.history.push("Withdraw");
//     return this.balance-=money;
//   },

//   transfer(receiver, money){
//     this.history.push("Transfer");
//     receiver.history.push("Transfer")
//     this.balance-=money;
//     receiver.balance+=money;
//     return `Money successfully transferred from ${this.numberOfCount} to ${receiver.numberOfCount}!`
//   }
// };

// console.log(count1.infoAboutCount);
// count1.deposit(200);
// console.log(count1.infoAboutCount);
// count1.withdraw(100);
// console.log(count1.infoAboutCount);
// console.log(count2.infoAboutCount);
// console.log(count1.transfer(count2, 200));
// console.log(count1.infoAboutCount);
// console.log(count2.infoAboutCount);
// console.log(count1.historyOfCount);
// console.log(count2.historyOfCount);

/* Task 4 */
//
// const library = {
//   books: [],
//
//   addBook(title, author, year, isbn) {
//     const newBook = {
//       title:title,
//       author:author,
//       year:year,
//       isbn:isbn
//     }
//     this.books.push(newBook);
//     return `Book "${title}" added successfully.`;
//   },
//
//   searchBook(query) {
//     return this.books.filter(
//         (book) =>
//             book.title.toLowerCase().includes(query.toLowerCase())||
//             book.author.toLowerCase().includes(query.toLowerCase()),
//     );
//   },
//
//   filterByAuthor(author) {
//     return this.books.filter((book) => book.author.toLowerCase().includes(author.toLowerCase()));
//   },
//
//   filterByYearRange(minYear, maxYear) {
//     return this.books.filter((book) => book.year >= minYear && book.year <= maxYear );
//   },
//
//   statistics() {
//     if (this.books.length === 0) {
//       return "List is empty!";
//     }
//     const years = this.books.map((book) => book.year);
//     return {
//       totalNumberOfBooks: this.books.length,
//       oldestBooks: Math.min(...years),
//       newestBooks: Math.max(...years),
//     }
//   }
// };
//
//
// library.addBook("1984", "George Orwell", 1949, "ISBN-001");
// library.addBook("Кёроглы", "Народное творчество", 1800, "ISBN-002");
// library.addBook("Аршин Мал Алан", "Узеира Гаджибейли", 1913, "ISBN-003");
//
// console.log(library.searchBook("Кёроглы"));
// console.log(library.searchBook("George Orwell"));
// console.log(library.filterByAuthor("Узеира Гаджибейли"));
// console.log(library.filterByYearRange(1800,2025));
// console.log(library.statistics());


/* Task 5 */
//
// const shoppingCart = {
//   products: [
//     { name: "Apple iPhone", price: 1000, quantity: 1, taxPercent: 18 },
//     { name: "Samsung TV", price: 800, quantity: 2, taxPercent: 18 },
//     { name: "Book", price: 20, quantity: 3, taxPercent: 0 }
//   ],
//
//   get allProducts() {
//     return this.products;
//   },
//
//   calculateTotalPrice(){
//     let total = 0;
//     this.products.map(product => total += product.price);
//     return total;
//   },
//
//   calculateTax(){
//     let total = 0;
//     this.products.map(product => total += product.price * product.taxPercent/100);
//     return total;
//   },
//
//   totalPriceWithTax(){
//     let totalWithoutTax = 0;
//     let totalTax = 0;
//     this.products.map(product => totalWithoutTax += product.price);
//     this.products.map(product => totalTax += product.price * product.taxPercent/100);
//     return totalWithoutTax- totalTax;
//   },
//
//   addProduct(name, price,quantity,taxPercent){
//     let product ={
//       name: name,
//       price: price,
//       quantity: quantity,
//       taxPercent: taxPercent
//     }
//     this.products.push(product);
//     return `Product ${name}, successfully added !`;
//   },
//
//   removeProduct(productName){
//     this.products = this.products.filter(product => product.name !== productName);
//     return `Product ${name}, successfully deleted! !`;
//   },
//
//   clearCart(){
//     this.products = [];
//     return "All products, were successfully deleted!";
//   }
// }
//
// console.log(shoppingCart.calculateTotalPrice());
// console.log(shoppingCart.calculateTax());
// console.log(shoppingCart.totalPriceWithTax());
// console.log(shoppingCart.addProduct("Xiaomi", 580, 5, 20));
// console.log(shoppingCart.allProducts);
// console.log(shoppingCart.removeProduct("Xiaomi"));
// console.log(shoppingCart.allProducts);
// console.log(shoppingCart.clearCart());
// console.log(shoppingCart.allProducts);


/* Task 6 */

// const users = {
//   "user1": { name: "Ali", age: 25, city: "Baku", salary: 1500 },
//   "user2": { name: "Leyla", age: 30, city: "Ganja", salary: 1800 },
//   "user3": { name: "Rashad", age: 28, city: "Baku", salary: 2000 },
//   "user4": { name: "Nigar", age: 35, city: "Sumgait", salary: 2200 }
// };
//
// // 1
// const usersArray = Object.values(users);
// console.log(usersArray);
//
// // 2
// const groupedByCity = usersArray.reduce((acc, user) => {
//   if (!acc[user.city]) acc[user.city] = [];
//   acc[user.city].push(user);
//   return acc;
// }, {});
// console.log(groupedByCity);
//
// // 3
// const avgSalary = usersArray.reduce((acc, user) => acc + user.salary,0);
// console.log(avgSalary);
//
// // 4
// const highestSalaryUser = usersArray.reduce((acc, user) => user.salary > acc.salary ? user : acc);
// console.log(highestSalaryUser);
//
// // 5
// const filterByAge = usersArray.filter((user) => user.age < 30);
// console.log(filterByAge);
//
// // 6
// const filterBySalary = usersArray.reduce((acc, user) => {
//   if(user.salary > 1800){
//     acc.push(user.name);
//   }
//   return acc;
//   }, []);
// console.log(filterBySalary);

/* Task 7 */
//
// const configuration = {
//   defaultSettings: {
//     language: "az",
//     theme: "light",
//     notifications: true,
//     autosave: 10, // minutes
//     fontSize: 14
//   },
//
//   userSettings: {},
//
//   setSetting(key, value) {
//     this.userSettings[key] = value;
//   },
//
//   getSetting(key) {
//     if(key in this.userSettings) {
//       return this.userSettings[key];
//     }
//     return this.defaultSettings[key];
//   },
//
//   resetSettings() {
//     this.userSettings = {};
//   },
//
//   getAllSettings() {
//     return {...this.defaultSettings, ...this.userSettings};
//   },
//
//   exportSettings() {
//     return JSON.stringify(this.getAllSettings());
//   },
//
//   importSettings(jsonString) {
//     const settings = JSON.parse(jsonString);
//     this.userSettings = {...settings};
//   }
// };
//
// configuration.setSetting("language", "ru");
// configuration.setSetting("theme", "dark");
// configuration.setSetting("notifications", "false");
// configuration.setSetting("autosave", "25");
// configuration.setSetting("fontsize", "20");
//
//
// console.log(configuration.getSetting("fontsize"));
// console.log(configuration.getSetting("theme"));
// console.log(configuration.getAllSettings());
//
// exportData = configuration.exportSettings();
// console.log(exportData);
//
// configuration.resetSettings();
// console.log(configuration.getAllSettings());
//
// configuration.importSettings(exportData);
// console.log(configuration.getAllSettings());


/* Task 8 */

// const textAnalyzer = {
//   text: "",
//
//   setText(newText) {
//     this.text = newText;
//     return this;
//   },
//
//   letterCount() {
//     return this.text.replace(/\s+/g, "").length;
//   },
//   wordCount() {
//     return this.text.trim().split(/\s+/).length;
//   },
//
//   sentenceCount() {
//     return (this.text.match(/[.!?]/g) || []).length;
//   },
//
//   longestWord() {
//     const words = this.text
//         .toLowerCase()
//         .replace(/[^a-zа-яё0-9\s]/gi, "")
//         .split(/\s+/);
//     return words.reduce((longest, word) =>
//         word.length > longest.length ? word : longest, ""
//     );
//   },
//
//   wordFrequency() {
//     const words = this.text
//         .toLowerCase()
//         .replace(/[^a-zа-яё0-9\s]/gi, "")
//         .split(/\s+/);
//     return words.reduce((acc, word) => {
//       acc[word] = (acc[word] || 0) + 1;
//       return acc;
//     }, {});
//   },
//
//   mostFrequentWord() {
//     const freq = this.wordFrequency();
//     let maxWord = "";
//     let maxCount = 0;
//     for (let word in freq) {
//       if (freq[word] > maxCount) {
//         maxCount = freq[word];
//         maxWord = word;
//       }
//     }
//     return { word: maxWord, count: maxCount };
//   },
//
//   averageWordLength() {
//     const words = this.text
//         .replace(/[^a-zа-яё0-9\s]/gi, "")
//         .split(/\s+/);
//     const totalLength = words.reduce((sum, word) => sum + word.length, 0);
//     return (totalLength / words.length).toFixed(2);
//   },
//
//   statistics() {
//     return {
//       letters: this.letterCount(),
//       words: this.wordCount(),
//       sentences: this.sentenceCount(),
//       longestWord: this.longestWord(),
//       wordFrequency: this.wordFrequency(),
//       mostFrequentWord: this.mostFrequentWord(),
//       averageWordLength: this.averageWordLength()
//     };
//   }
// };
//
// console.log(
//     textAnalyzer
//         .setText("This text will be analyzed. Very interesting text!")
//         .statistics()
// );



/* Task 9 */

// const priceCalculator = {
//   taxRates: {
//     standard: 18,
//     food: 0,
//     luxury: 25
//   },
//
//   discountCodes: {
//     "STUDENT": 10,
//     "VIP": 15,
//     "FIRST": 20
//   },
//
//   deliveryPrices: {
//     "Baku": 5,
//     "other_city": 10,
//     "village": 15
//   },
//
//   // Write these methods:
//   calculateProductPrice(basePrice, category) {
//     return basePrice + (basePrice * this.taxRates[category]/100);
//   },
//
//   applyDiscount(price, discountCode) {
//     return price - (price * this.discountCodes[discountCode]/100);
//   },
//
//   calculateDelivery(location, orderValue) {
//     if(orderValue >= 100) return 0;
//     return this.deliveryPrices[location];
//   },
//
//   calculateTotal(productsList, discountCode, deliveryAddress) {
//     let total =  productsList.reduce((acc, product) => {
//       return acc + this.calculateProductPrice(product.price, product.category) * product.quantity;
//     },0);
//
//     total = this.applyDiscount(total, discountCode);
//
//     const deliveryPrice = this.calculateDelivery(deliveryAddress, total);
//
//     return {
//       productsTotal: total,
//       delivery: deliveryPrice,
//       grandTotal: total + deliveryPrice
//     };
//   },
//
//   createInvoice(customerInfo, orderDetails) {
//     const totalInfo = this.calculateTotal(orderDetails.products, orderDetails.discountCode, orderDetails.deliveryAddress);
//     return {
//       customer: customerInfo,
//       order: orderDetails,
//       summary: totalInfo,
//     };
//   }
// };
//
// const products = [
//   { name: "Laptop", price: 10, category: "standard", quantity: 1 },
//   { name: "Apple", price: 60, category: "food", quantity: 10 },
//   { name: "Luxury Watch", price: 50, category: "luxury", quantity: 1 }
// ];
//
// const invoice = priceCalculator.createInvoice(
//     { name: "Ramazan", address: "Sumqayit" },
//     { products, discountCode: "VIP", deliveryAddress: "other_city" },
// );
//
// console.log(invoice);