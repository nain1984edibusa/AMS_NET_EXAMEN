import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'capitalize'
})
export class CapitalizePipe implements PipeTransform {

  transform(value: string | null | undefined): string {
    if (!value) {
      return '';
    }
    return value.replace(/\b\w/g, (char, index) => {
      if (index === 0 || value[index - 1].match(/\s/)) {
        return char.toUpperCase();
      }
      return char;
    });
  }

}
