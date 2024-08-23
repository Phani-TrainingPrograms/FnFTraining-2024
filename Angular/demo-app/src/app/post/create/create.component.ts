import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { PostService} from "../post.service";
import { Post } from '../post';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  postedData : Post = {} as Post;
  constructor(private service : PostService, private router : Router) {
    
  }
  
  onSubmit(){
    console.log(JSON.stringify(this.postedData));
    this.service.create(this.postedData).subscribe((res : any)=>{
      console.log(res);
      alert("Post is posted successfully");
      this.router.navigateByUrl("post/index")
    })
  }
}
//implement the code behind