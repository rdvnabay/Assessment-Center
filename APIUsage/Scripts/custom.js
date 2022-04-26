//task 1.1
//Get the data from controller (use ajax)
$(".get-data-btn").click(function () {
    $.ajax({
        url: "Home/GetData",
        type: "GET",
        success: function (accounts) {
           displayTable(accounts)
        }
    })
    //display the data in form of a table
    function displayTable(accounts) {
        let tableRow = "";

        for (let account of accounts) {
            tableRow += `
                 <tr class=${account.Id}>
                     <td>${account.Id}</td>
                     <td>${account.Pan}</td>
                     <td>${account.Pin}</td>
                     <td>${account.Balance}</td>
                 </tr> `
        }

        let table = `
               <table class="table table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Pan</th>
                            <th>Pin</th>
                            <th>Balance</th>
                        </tr>
                    </thead>
                    <tbody>
                      ${tableRow}
                    </tbody>
                </table>`

        $(".table-wrapper").html(table);
    }
});
//end task 1.2


//task 1.2
//remove data with null
$(".remove-data-with-null-btn").click(function () {
    //Find a way to remove the data which contains null
    $('tr.null').remove()

});
//end task 1.2

//task 2.3
setInterval(() => {
    $.ajax({
        url: "https://api.coindesk.com/v1/bpi/currentprice.json",
        methd: "GET",
        success: function (response) {
            let bitCoin = JSON.parse(response);
            $('#usd').text(bitCoin.bpi.USD.rate);
            $('#eur').text(bitCoin.bpi.EUR.rate);
            $('#gbp').text(bitCoin.bpi.GBP.rate);
        }
    })
}, 10000)
//end task 2.3