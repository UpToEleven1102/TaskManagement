import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone',
})
export class PhonePipe implements PipeTransform {
  transform(value: string, ...args: unknown[]): unknown {
    value = value.charAt(0) !== '+' ? value.replace('+', '') : value;

    let newStr = '';
    let i = 0;

    for (; i < Math.floor(value.length / 2) - 1; i++) {
      newStr = newStr + value.substr(i * 2, 2) + '-';
    }

    return newStr + value.substr(i * 2);
  }
}
