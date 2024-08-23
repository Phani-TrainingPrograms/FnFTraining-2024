import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { Post } from '../post';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PostPipe } from '../post.pipe';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, PostPipe],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent implements OnInit {
  /*
  todo:
  Inject the required dependencies
  Implement OnInit interface. 
  */
  place : string = "";

  posts : Post[] = [];
  constructor(private service : PostService) {    
    
  }

  ngOnInit(): void {
    this.service.getAll().subscribe((res : Post[])=>{
      this.posts = res;
    })
  }

  onDelete(id : number){
    const val = confirm("Do U really want to delete?")
    if(!val){
      return;
    }
    this.service.delete(id).subscribe(res =>{
      alert("Record deleted Successfully")
    })
  }
}
