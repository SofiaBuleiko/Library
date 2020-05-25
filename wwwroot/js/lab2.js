const uri = 'api/PublishingHouses';
let publishingHouses = [];

function getPublishingHouses() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayPublishingHouses(data))
        .catch(error => console.error('Unable to get PublishingHouses.', error));
}

function addPublishingHouse() {
    const addNameTextbox = document.getElementById('add-name');
    const addCityTextbox = document.getElementById('add-city');

    const publishingHouse = {
        name: addNameTextbox.value.trim(),
        city: addCityTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(publishingHouse)
    })
        .then(response => response.json())
        .then(() => {
            getPublishingHouses();
            addNameTextbox.value = '';
            addCityTextbox.value = '';
        })
        .catch(error => console.error('Unable to add publishingHouse.', error));
}

function deletePublishingHouse(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getPublishingHouses())
        .catch(error => console.error('Unable to delete publishingHouse.', error));
}

function displayEditForm(id) {
    const publishingHouse = publishingHouses.find(publishingHouse => publishingHouse.id === id);

    document.getElementById('edit-id').value = publishingHouse.id;
    document.getElementById('edit-name').value = publishingHouse.name;
    document.getElementById('edit-city').value = publishingHouse.city;
    document.getElementById('editForm').style.display = 'block';
}

function updatePublishingHouse() {
    const publishingHouseId = document.getElementById('edit-id').value;
    const publishingHouse = {
        id: parseInt(publishingHouseId, 10),
        name: document.getElementById('edit-name').value.trim(),
        city: document.getElementById('edit-city').value.trim()
    };

    fetch(`${uri}/${publishingHouseId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(publishingHouse)
    })
        .then(() => getPublishingHouses())
        .catch(error => console.error('Unable to update publishingHouse.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayPublishingHouses(data) {
    const tBody = document.getElementById('publishingHouses');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(publishingHouse => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${publishingHouse.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deletePublishingHouse(${publishingHouse.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(publishingHouse.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(publishingHouse.city);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    publishingHouses = data;
}
