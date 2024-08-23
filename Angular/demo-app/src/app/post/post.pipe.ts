import { Pipe, PipeTransform } from '@angular/core';
import { Post } from './post';

//pipe is used to transform any data into a representation in the user interface. pipe is used using the pipe key of the keyboard. 
//All pipes are classes that implement an interface called PipeTransform and has a Directive called Pipe that contain info like name on how to we use it in our UI.
@Pipe({
  name: 'post',
  standalone: true
})
export class PostPipe  implements PipeTransform {
  transform(input: Post[], ...args: string[]): Post[] {
    const searchCriteria = args[0];
    return input.filter(post => post.title.includes(searchCriteria)) ;
  }
}
