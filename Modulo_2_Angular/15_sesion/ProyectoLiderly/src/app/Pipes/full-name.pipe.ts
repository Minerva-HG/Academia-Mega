import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'fullName'
})
export class FullNamePipe implements PipeTransform {

  transform(user: any): string {
    return `${user.name.title} ${user.name.first} ${user.name.last}`;
  }

}
