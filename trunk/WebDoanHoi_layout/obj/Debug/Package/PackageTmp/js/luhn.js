
/* Luhn algorithm number checker - (c) 2005-2009 - planzero.org            *
 * This code has been released into the public domain, however please      *
 * give credit to the original author where possible.                      */

function luhn_check(number) {

  //B1: Loai bo khoang trong va cac ky tu khong phai la so
  var number=number.replace(/\D/g, '');
 
  // Kiem tra tinh hop le cua day so bang thuat toan luhn (modula 10 hay mod 10)
  // Bat dau tu cuoi chuoi --> (le + chan*2)mod10 = 0 --> hop le
  //                                              !=0 --> khong hop le  
  var number_length=number.length;
  var parity=number_length % 2;
 
  // Loop through each digit and do the maths
  var total=0;
  for (i=0; i < number_length; i++) {
    var digit=number.charAt(i);
    // Multiply alternate digits by two
    if (i % 2 == parity) {
      digit=digit * 2;
      // If the sum is two digits, add them together (in effect)
      if (digit > 9) {
        digit=digit - 9;
      }
    }
    // Total up the digits
    total = total + parseInt(digit);
  }
 
  // If the total mod 10 equals 0, the number is valid
  if (total % 10 == 0) {
    return true;
  } else {
    return false;
  }
}
