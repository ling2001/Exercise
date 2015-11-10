
var customer = function (id, customerName, contactName, address, city, postalCode, country) {
    var self = this;
    self.CustomerID = id;
    self.CustomerName = customerName;
    self.ContactName = contactName,
    self.Address = address;
    self.City = city;
    self.PostalCode = postalCode;
    self.Country = country;

    this.addCustomer = function () {
        $.ajax({
            url: "/api/customer/",
            type: 'post',
            data: ko.toJSON(this),
            contentType: 'application/json',
            success: function (result) {
                alert("New Customer added.")
            }
        });
    }
}
var ClickCustomerViewModel = function () {
    var self = this;
    self.customers = ko.observableArray([]);
    self.getCustomes = function () {
        $('#createCustomerID').hide();
        self.customers.removeAll();
        $.getJSON("/api/customer/", function (data) {
            $.each(data, function (key, value) {
                self.customers.push(new customer(value.CustomerID, value.CustomerName, value.ContactName, value.Address, value.City, value.PostalCode, value.Country));
            });
        });
    };
};

$(document).ready(function () {
    $('#customerlistID').hide();
    $('#createCustomerID').hide();
    ko.applyBindings(new ClickCustomerViewModel(), document.getElementById('displayNode'));
    ko.applyBindings(new customer(), document.getElementById('createNode'));
});

function show(target) {
    $('#createCustomerID').show();
    $('#customerlistID').hide();

}
function showlist(target) {
    $('#createCustomerID').hide();
    $('#customerlistID').show();
}