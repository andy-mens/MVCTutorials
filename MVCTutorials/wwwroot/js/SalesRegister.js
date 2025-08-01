
const quantityInput = document.getElementById('quantity');
const unitPriceInput = document.getElementById('unitPrice');
const totalInput = document.getElementById('total');
const SALES_ITEMS_KEY = 'saleItems';
localStorage.setItem(SALES_ITEMS_KEY, []); // Clear local storage on page load

const customers = [ "Customer 1", "Customer 2", "Customer 3", "Customer 4" ];
const items = ["Item 1", "Item 2", "Item 3", "Item 4", "Item 5" ];

function updateTotal() {
    const quantity = parseFloat(quantityInput.value) || 0;
    const price = parseFloat(unitPriceInput.value) || 0;
    totalInput.value = (quantity * price).toFixed(2);
}

quantityInput.addEventListener('input', updateTotal);
unitPriceInput.addEventListener('input', updateTotal);

document.getElementById('salesForm').addEventListener('submit', function (e) {
    e.preventDefault();

    const customer = document.getElementById('customerName').value;
    const product = document.getElementById('productName').value;
    const quantity = quantityInput.value;
    const unitPrice = unitPriceInput.value;
    const total = totalInput.value;

    customers.forEach(c => {
        console.log(c);
        console.log(customer);
    });


    const tableBody = document.getElementById('salesTableBody');
    const row = document.createElement('tr');

    row.innerHTML = `
    <td>${product}</td>
    <td>${quantity}</td>
    <td>${parseFloat(unitPrice).toFixed(2)}</td>
    <td>${total}</td>
    `;

    tableBody.appendChild(row);

    // Reset form
    document.getElementById('productName').value = '';
    quantityInput.value = '';
    totalInput.value = '';
    unitPriceInput.value = '';

    const newSaleItem = {
        product: product,
        quantity: quantity,
        unitPrice: unitPrice,
        total: total
    };

    let currentSaleItems = getSaleItems();
    currentSaleItems.push(newSaleItem);
    console.log('Current Sale Items:', currentSaleItems);
    saveSaleItems(currentSaleItems);
});

// Get references to the elements
const openPopupBtn = document.getElementById('openPopupBtn');
const popupOverlay = document.getElementById('popupOverlay');
const closePopupBtn = document.getElementById('closePopupBtn');
const confirmBtn = document.getElementById('confirmBtn');
const cancelBtn = document.getElementById('cancelBtn');
const orderSummaryElement = document.getElementById('order-summary');
const orderGrandTotal = document.getElementById('order-grand-total');
const orderSummaryContainerElement = document.getElementById('order-summary-container');

// Function to open the pop-up
function openPopup() {
    popupOverlay.classList.add('active');

    //populate the pop up window
    document.getElementById('invoice-customer-name').innerHTML = document.getElementById('customerName').value;
    let orderSummaryString = '';
    let grandTotal = 0;

    if (localStorage.getItem(SALES_ITEMS_KEY).length > 0) {
        JSON.parse(localStorage.getItem(SALES_ITEMS_KEY)).forEach((item, index) => {
            orderSummaryString += `<div class="d-flex d-flex-space-between">
                            <div class="d-flex justify-content-start align-left">
                                <div>
                                    <h6>${item.product}</h6>
                                    <p>Unit Price: GHS ${item.unitPrice}</p>
                                </div>
                            </div>
                       
                            <div class="d-flex justify-content-end">
                                <div>
                                    <h6> GHS ${item.total}</h6>
                                    <p>Qty: ${item.quantity}</p>
                                </div>
                            </div>
                        
                    </div>`;

            grandTotal += Number(item.total);
            //grandTotal = parseFloat(grandTotal).toFixed(2);
        });

        orderSummaryElement.innerHTML = orderSummaryString;
        orderGrandTotal.innerHTML = `Grand Total: GHS ${parseFloat(grandTotal).toFixed(2)}`;

    } else {
        orderSummaryElement.innerHTML = "No items added to cart";
    }
}

// Function to close the pop-up
function closePopup() {
    popupOverlay.classList.remove('active');
}

// Event listeners
openPopupBtn.addEventListener('click', openPopup);
closePopupBtn.addEventListener('click', closePopup);
// Close pop-up if clicking outside the pop-up box (on the overlay)
popupOverlay.addEventListener('click', function (event) {
    if (event.target === popupOverlay) {
        closePopup();
    }
});

//// Example actions for the pop-up buttons
//confirmBtn.addEventListener('click', function () {
//    alert('Confirm button clicked!');
//    closePopup();
//});

//cancelBtn.addEventListener('click', function () {
//    alert('Cancel button clicked!');
//    closePopup();
//});

// Function to save a list of product objects to local storage
function saveSaleItems(item) {
    try {
        // Convert the list of objects into a JSON string
        const productJSON = JSON.stringify(item);

        // Save the JSON string to local storage under a specific key
        localStorage.setItem(SALES_ITEMS_KEY, productJSON);

        console.log('Product list saved successfully to local storage.');
    } catch (error) {
        console.error('Error saving product list to local storage:', error);
    }
}

// Function to retrieve the list of product objects from local storage
function getSaleItems() {
    try {
        // Retrieve the JSON string from local storage
        const productsJSON = localStorage.getItem(SALES_ITEMS_KEY);

        // If no data is found, return an empty array
        if (productsJSON === null) {
            console.log('No product list found in local storage. Returning empty array.');
            return [];
        }

        // Parse the JSON string back into a JavaScript array of objects
        console.log(productsJSON);
        const items = JSON.parse(productsJSON);
        console.log('Product list retrieved successfully from local storage:', items);
        return items;
    } catch (error) {
        console.error('Error retrieving product list from local storage:', error);
        return []; // Return empty array in case of an error during retrieval/parsing
    }
}

document.getElementById("confirm-checkout").addEventListener("click", () => {
    print(orderSummaryContainerElement.innerHTML);
});
