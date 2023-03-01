import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthService } from 'src/app/auth/data-access/auth.service';
import { CommentModel, CreateCommentModel, CurrentComment, CurrentCommentType } from 'src/app/models/comment';
import { CommentService } from '../../data-access/comment.service';

@Component({
  selector: 'comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent implements OnInit {
  @Input() comment!: CommentModel;
  @Input() currentComment!: CurrentComment | null;

  @Output() setCurrentComment: EventEmitter<CurrentComment | null> = new EventEmitter<CurrentComment | null>();
  @Output() addComment: EventEmitter<CreateCommentModel> = new EventEmitter<CreateCommentModel>();

  canReply: boolean = true;
  canEdit: boolean = true;
  canDelete: boolean = true;

  currentCommentType = CurrentCommentType;

  replies: CommentModel[] = [];

  isAuthenticated: boolean = false;

  constructor(
    private commentService: CommentService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.isAuthenticated.subscribe(a => {
      this.isAuthenticated = a;
    })
  }

  onGetReplies(){
    this.commentService.getAllReplies(this.comment.id).subscribe(c => {
      this.replies = c;
    })
  }

  onSetCurrentComment(comment: CurrentComment | null){
    this.setCurrentComment.emit(comment);
  }

  onAddComment(event: string, formData: FormData | null){
    this.addComment.emit({text: event, parentCommentId: this.comment.id, formData: formData});
  }

  onCancelComment(){
    console.log('here');
    this.setCurrentComment.emit(null);
  }

  isReply(){
    if (!this.currentComment){
      return false;
    }

    return this.currentComment.id == this.comment.id &&
      this.currentComment.type == this.currentCommentType.reply;
  }
}
