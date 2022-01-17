function palindrome(str) {
    let stringTest = str.replace(/\W/g, '').toLowerCase();;
    stringTest = stringTest.replace(/_/g, '')
    let check = true;
    for (let i = 0; i < stringTest.length / 2; i++) {
        if (stringTest[i] !== stringTest[stringTest.length - 1 - i]) {
            check = false;
        }

    }

    return check;
}

palindrome("eye");

