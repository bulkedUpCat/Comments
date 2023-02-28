import { Component, OnInit } from '@angular/core';
import { CommentModel, CreateCommentModel, CurrentComment } from 'src/app/models/comment';
import { CommentService } from '../../data-access/comment.service';

@Component({
  selector: 'comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.scss']
})
export class CommentsListComponent implements OnInit {
  comments: CommentModel[] = [];
  currentComment!: CurrentComment | null;

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

  onAddComment(model: CreateCommentModel){
    console.log(model.text, model.parentCommentId);
  }

  onSetCurrentComment(currentComment: CurrentComment | null){
    console.log(currentComment);
    this.currentComment = currentComment;
  }
}
