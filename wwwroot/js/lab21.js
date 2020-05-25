const uri = 'api/Books';
let books = [];
let publishingHouses = [];
var modal = document.getElementById("books");
let cur_publishingHouse = '';
function getBooks() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayBooks(data))
        .catch(error => console.error('Unable to get Books.', error));
}

function getBooksByPublishingHouse() {
    var publishingHouseName = document.getElementById('selectpublishingHouse').value;
    fetch(uri + `?publishingHousename=${publishingHouseName}`)
        .then(response => response.json())
        .then(data => _displayBooks(data))
        .catch(error => console.error('Unable to get books.', error));
}

function clearSelect() {
    document.getElementById('selectpublishingHouse').value = '';
    getBooks();
}

function getPublishingHouses() {
    fetch('api/PublishingHouses')
        .then(response => response.json())
        .then(data => _displayPublishingHouses(data))
        .catch(error => console.error('Unable to get publishingHouses.', error));
}
function _displayPublishingHouses(data) {
    var combo = document.getElementById("publishingHouses");
    var combo2 = document.getElementById("selectpublishingHouse");
    data.forEach(publishingHouse => {
        var opt = document.createElement('option');
        opt.appendChild(document.createTextNode(publishingHouse.name));
        var opt2 = document.createElement('option');
        opt2.appendChild(document.createTextNode(publishingHouse.name));
       
        combo.appendChild(opt);
        combo2.appendChild(opt2);
    });

    publishingHouses = data;
}

function addBook() {
    const addNameTextbox = document.getElementById('add-name');

    const addYearTextbox = document.getElementById('add-year');
    const addPagesTextbox = document.getElementById('add-pages');
    //const addPublishingHouseTextbox = document.getElementById('add-publishingHouse');
    const PublishingHouseName = document.getElementById('publishingHouses').value;
    let arr = [addNameTextbox.value.trim(), addYearTextbox.value.trim(), addPagesTextbox.value.trim(), PublishingHouseName];
    //const book = {
    //    name: addNameTextbox.value.trim(),
    //    year: addYearTextbox.value.trim(),
    //    pages: addPagesTextbox.value.trim(),
    //  // publishingHouse: addPublishingHouseTextbox.value.trim(),
    //    publishingHousename: PublishingHouseName.trim(),
    //   publishingHouseid: PublishingHouseId.trim(),
    //};

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
       // body: JSON.stringify(book)
      body: JSON.stringify(arr)
    })
        .then(response => response.json())
        .then(() => {
            getBooks();
            addNameTextbox.value = '';

            addYearTextbox.value = '';
            addPagesTextbox.value = '';
           // addPublishingHouseTextbox.value = '';
        }).then(response => response.json())
        .catch(error => console.error('Unable to add book.', error));
}

function deleteBook(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getBooks())
        .catch(error => console.error('Unable to delete book.', error));
}

function displayEditForm(id) {
    const book = books.find(book => book.id === id);

    document.getElementById('edit-id').value = book.id;
    document.getElementById('edit-name').value = book.name;
    document.getElementById('edit-year').value = book.year;
    document.getElementById('edit-pages').value = book.pages;
  // document.getElementById('edit-publishingHouse').value = book.publishingHouseName;
    document.getElementById('editForm').style.display = 'block';
}

function updateBook() {
    const bookId = document.getElementById('edit-id').value;
    const book = {
        id: parseInt(bookId, 10),
        name: document.getElementById('edit-name').value.trim(),

        year: document.getElementById('edit-yeary').value.trim(),
        pages: document.getElementById('edit-pages').value.trim(),
        publishingHousename: document.getElementById('edit-publishingHouse').value.trim()
    };
    const publishingHouseName = document.getElementById('edit-publishingHouses').value.trim();
    //fetch(`${uri}/${bookId}`, {
    //    method: 'PUT',
    //    headers: {
    //        'Accept': 'application/json',
    //        'Content-Type': 'application/json'
    //    },
    //    body: JSON.stringify(book)
    //})
    //    .then(() => getBooks())
    //    .catch(error => console.error('Unable to update book.', error));
    fetch(`${uri}${bookId}?publishingHouseName=${publishingHouseName}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    })
        .then(() => getBooks())
        .catch(error => console.error('Unable to update book.', error));
    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
    document.getElementById('addBook').style.display = 'none';

}


function _displayBooks(data) {
    const tBody = document.getElementById('books');
    tBody.innerHTML = '';
    const button = document.createElement('button');

    data.forEach(book => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${book.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteBook(${book.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNodeName = document.createTextNode(book.name);
        td1.appendChild(textNodeName);

        let td2 = tr.insertCell(1);
        let textNodeYear = document.createTextNode(book.year);
        td2.appendChild(textNodeYear);

        let td3 = tr.insertCell(2);
        let textNodePages = document.createTextNode(book.pages);
        td3.appendChild(textNodePages);

        let td4 = tr.insertCell(3);
        let textNodePublishingHouse = document.createTextNode(book.publishingHouseName);
        td4.appendChild(textNodePublishingHouse);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });

    books = data;
}
window.onclick = function (event) {

    if (event.target == modal) {
        modal.style.display = "none";
    }
}
