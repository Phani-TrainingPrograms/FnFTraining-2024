import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Post } from '../post';
import { PostService } from '../post.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit {
  //create fields to store the id and the post. 
  id! : number;
  post! : Post;
  //inject the Service, ActivatedRoute and Router as dependencies.
 
  constructor(
      private service : PostService, 
      private route : ActivatedRoute,
      private router : Router) {
   
    } 
  //extract the data from the service and bind it to the post.
  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.service.find(this.id).subscribe(res =>{
      this.post = res as Post;
    })
  }

  //implement the click event handler of the button for submit to call the service and redirect the page to the index.
  onSumbit(){
    this.service.update(this.id, this.post).subscribe(res =>{
      alert("Post is updated")
      this.router.navigateByUrl('post/index');
    })
  } 
  //implement the View of the Component. 
}
