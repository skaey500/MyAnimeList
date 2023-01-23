import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Constants } from '../util/constants';

@Pipe({
  name: 'DateTimeFormat',
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {
  override transform(value: any, args?: any): any {
    if (value) {
      return super.transform(value, 'yyyy-MM-dd')
    }
    else {
      return super.transform(new Date(), 'yyyy-MM-dd');
    }
  }
}
