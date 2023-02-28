import { Component, OnInit } from '@angular/core';
import { CommentModel, CurrentComment } from 'src/app/models/comment';
import { CommentService } from '../../data-access/comment.service';

@Component({
  selector: 'comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.scss']
})
export class CommentsListComponent implements OnInit {
  comments: CommentModel[] = [];
  currentComment!: CurrentComment;

  constructor(private commentService: CommentService) { }

  ngOnInit(): void {
    this.getAllComments();
  }

  getAllComments(){
    this.commentService.getAllComments().subscribe(c => {
      this.comments = c;
      console.log(this.comments);
    })
  }

  onAddComment(event: string){
    console.log(event);
  }
}
