import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

  constructor(private commentService: CommentService) { }

  ngOnInit(): void {
  }

  onGetReplies(){
    this.commentService.getAllReplies(this.comment.id).subscribe(c => {
      this.replies = c;
    })
  }

  onSetCurrentComment(comment: CurrentComment | null){
    this.setCurrentComment.emit(comment);
  }

  onAddComment(event: string){
    this.addComment.emit({text: event, parentCommentId: this.comment.id});
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
