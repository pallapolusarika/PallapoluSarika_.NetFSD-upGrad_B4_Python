

const products = [
    "Laptop",
    "Mobile",
    "Headphones",
    "Keyboard",
    "Mouse",
    "Monitor",
    "Charger",
    "Smart Watch"
];

let filteredProducts = [...products]; // State copy


const searchInput = document.getElementById("searchInput");
const productList = document.getElementById("productList");



function renderProducts(list) {
    productList.innerHTML = "";

    if (list.length === 0) {
        productList.innerHTML = "<li>No Results Found</li>";
        return;
    }

    list.forEach(product => {
        const li = document.createElement("li");
        li.textContent = product;
        productList.appendChild(li);
    });
}



function filterProducts(searchTerm) {
    filteredProducts = products.filter(product =>
        product.toLowerCase().includes(searchTerm.toLowerCase())
    );

    renderProducts(filteredProducts);
}



searchInput.addEventListener("input", function (e) {
    filterProducts(e.target.value);
});


renderProducts(products);