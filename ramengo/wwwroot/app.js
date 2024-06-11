const apiKey = 'YOUR_API_KEY';
const apiBaseUrl = 'https://localhost:7291'; // Certifique-se de que esta URL está correta

document.addEventListener('DOMContentLoaded', function () {
    loadBroths();
    loadProteins();

    document.getElementById('orderButton').addEventListener('click', placeOrder);
});

async function loadBroths() {
    try {
        const response = await fetch(`${apiBaseUrl}/api/Broth`, {
            headers: { 'x-api-key': apiKey }
        });
        if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);

        const broths = await response.json();
        const brothsContainer = document.getElementById('broths');
        broths.forEach(broth => {
            const brothElement = document.createElement('div');
            brothElement.className = 'option';
            brothElement.dataset.id = broth.id;
            brothElement.innerHTML = `<img src="${broth.imageInactive}" alt="${broth.name}"><p>${broth.name}</p>`;
            brothElement.addEventListener('click', () => selectOption(brothElement, 'broth'));
            brothsContainer.appendChild(brothElement);
        });
    } catch (error) {
        console.error('Failed to load broths:', error);
    }
}

async function loadProteins() {
    try {
        const response = await fetch(`${apiBaseUrl}/api/Protein`, {
            headers: { 'x-api-key': apiKey }
        });
        if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);

        const proteins = await response.json();
        const proteinsContainer = document.getElementById('proteins');
        proteins.forEach(protein => {
            const proteinElement = document.createElement('div');
            proteinElement.className = 'option';
            proteinElement.dataset.id = protein.id;
            proteinElement.innerHTML = `<img src="${protein.imageInactive}" alt="${protein.name}"><p>${protein.name}</p>`;
            proteinElement.addEventListener('click', () => selectOption(proteinElement, 'protein'));
            proteinsContainer.appendChild(proteinElement);
        });
    } catch (error) {
        console.error('Failed to load proteins:', error);
    }
}

function selectOption(element, type) {
    document.querySelectorAll(`#${type}s .option`).forEach(option => option.classList.remove('selected'));
    element.classList.add('selected');
}

async function placeOrder() {
    const selectedBroth = document.querySelector('#broths .option.selected');
    const selectedProtein = document.querySelector('#proteins .option.selected');

    if (!selectedBroth || !selectedProtein) {
        alert('Please select both a broth and a protein!');
        return;
    }
    const orderRequest = {
        brothId: selectedBroth.dataset.id,
        proteinId: selectedProtein.dataset.id
    };

    try {
        const response = await fetch(`${apiBaseUrl}/api/Order`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'x-api-key': apiKey
            },
            body: JSON.stringify(orderRequest)
        });

        if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);

        const orderResponse = await response.json();
        alert(`Order placed successfully! Your order ID is ${orderResponse.id}`);
    } catch (error) {
        alert('Failed to place order. Please try again.');
    }
}
