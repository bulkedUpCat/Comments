import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/data-access/auth.service';
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
  userId: string | null = null;

  constructor(
    private commentService: CommentService,
    private authService: AuthService) { }

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
    this.commentService.createComment(model).subscribe(c => {
      this.getAllComments();
      this.currentComment = null;
    });
  }

  onSetCurrentComment(currentComment: CurrentComment | null){
    console.log(currentComment);
    this.currentComment = currentComment;
  }

  getCurrentUserId(){
    this.userId = this.authService.getCurrentUserId();
  }
}
