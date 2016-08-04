var ContactManager = function() {




    return {

    };

}();

var DataManager = function() {

    var customerData = [
        {
            "CustomerID": 932,
            "FirstName": "Sam",
            "LastName": "Smith",
            "MiddleName": "A",
            "CompanyName": "EDS",
            "SalesPerson": "Ed Mcneil",
            "EmailAddress": "sghaneka@yahoo.com",
            "Phone": "973-424-4233"
        },
        {
            "CustomerID": 452,
            "FirstName": "Treee",
            "LastName": "Hudson",
            "MiddleName": "A",
            "CompanyName": "EDS",
            "SalesPerson": "Ed Mcneil",
            "EmailAddress": "sghaneka@yahoo.com",
            "Phone": "973-424-4233"
        }, {
            "CustomerID": 124,
            "FirstName": "Gary",
            "LastName": "Goose",
            "MiddleName": "A",
            "CompanyName": "EDS",
            "SalesPerson": "Ed Mcneil",
            "EmailAddress": "sghaneka@yahoo.com",
            "Phone": "973-424-4233"
        }];



    function getContacts() {
        return customerData;
    }


    return {
        contacts: getContacts
    }
}();

