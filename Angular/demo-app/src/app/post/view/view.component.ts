import { Component, OnInit } from '@angular/core';
import { Post } from '../post';
import { PostService } from '../post.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css'
})
export class ViewComponent implements OnInit {
  id : number = 0; //represents the Id of the record to find
  post : Post = {} as Post;//found record.

  constructor(private service : PostService, private router : Router, private route : ActivatedRoute ){

  }
  ngOnInit(): void {
    //extract the Id from the route. 
    this.id = this.route.snapshot.params['id'];
    this.service.find(this.id).subscribe(res =>{
      this.post = res as Post;
    })
  }

}
