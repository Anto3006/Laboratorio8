class DataTable {
    constructor(dataOrigin, context) {
        this.dataOrigin = dataOrigin;
        this.context = context;
    }

    createHeader(table) {
        let row = document.createElement("tr");
        let tableHead = document.createElement("thead")
        table.appendChild(tableHead)
        let headers = ["Id", "Quantity", "Name", "Price"]
        for (const header of headers) {
            let headerElement = document.createElement("th")
            headerElement.innerHTML = `${header}`
            row.appendChild(headerElement)
        }
        tableHead.appendChild(row);
    }

    createBody(table,data) {
        let tableBody = document.createElement("tbody")
        table.appendChild(tableBody)
        let row = document.createElement("tr");
        for (const object of data) {
            for (const key in object) {
                let rowValue = document.createElement("td")
                rowValue.innerHTML = `${object[key]} `
                row.appendChild(rowValue)
            }
            tableBody.appendChild(row);
            row = document.createElement("tr");
        }
    }

    fillContext() {
        fetch(this.dataOrigin)
            .then(response => {
                return response.json()
            })
            .then(data => {
                let table = document.createElement("table");
                table.className = "table"
                this.createHeader(table)
                this.createBody(table,data)
                this.context.appendChild(table)
                console.log(this.context)
            })
            .catch(error => {
                console.log(error);
            })
    }
}