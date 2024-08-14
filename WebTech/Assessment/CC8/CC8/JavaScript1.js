//  multiply two numbers
function multiplyNumbers() {
    var num1 = document.getElementById('N1').value;
    var num2 = parseFloat(document.getElementById('N2').value);
    var result = num1 * num2;
    document.getElementById('result').innerText = 'Result: ' + result;
}
document.getElementById('b1').onclick = multiplyNumbers;



//  to divide two numbers
function divideNumbers() {
    var num1 = parseFloat(document.getElementById('N1').value);
    var num2 = parseFloat(document.getElementById('N2').value);

    if (num2 !== 0) {
        var result = num1 / num2;
        document.getElementById('result').innerText = 'Result: ' + result;
    } else {
        document.getElementById('result').innerText = 'positive numbers can not divided by zero';
    }
}

document.getElementById('b2').onclick = divideNumbers;






button.addEventListener('click', function () {

    message.textContent = 'Button clicked successfully';
});