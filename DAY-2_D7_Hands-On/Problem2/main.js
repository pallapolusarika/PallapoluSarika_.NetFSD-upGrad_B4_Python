// Import function from cart.js
import { calculateTotal } from "./cart.js";

// Store product objects in array
const products = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 500, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 }
];

// Format product lines using map()
const invoiceLines = products.map(product => {
    return `${product.name} - ₹${product.price} x ${product.quantity} = ₹${product.price * product.quantity}`;
});

// Calculate total cart value
const totalAmount = calculateTotal(products);

// Display formatted invoice
console.log("------ INVOICE ------");
invoiceLines.forEach(line => console.log(line));
console.log("----------------------");
console.log(`Total Amount: ₹${totalAmount}`);