import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthService } from 'src/app/auth/data-access/auth.service';
import { CommentModel, CommentSubmitModel, CreateCommentModel, CurrentComment, CurrentCommentType, UpdateCommentModel } from 'src/app/models/comment';
import { BlobService } from 'src/app/services/blob.service';
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
  @Output() updateComment: EventEmitter<UpdateCommentModel> = new EventEmitter<UpdateCommentModel>();
  @Output() deleteComment: EventEmitter<string> = new EventEmitter<string>();

  canReply: boolean = true;
  canEdit: boolean = true;
  canDelete: boolean = true;

  currentCommentType = CurrentCommentType;

  replies: CommentModel[] = [];

  isAuthenticated: boolean = false;

  constructor(
    private commentService: CommentService,
    private authService: AuthService,
    private blobService: BlobService) { }

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

  onUpdateComment(text: string, formData: FormData | null, id: string){
    const updateModel = new UpdateCommentModel();
    updateModel.id = id;
    updateModel.text = text;
    updateModel.formData = formData;

    this.updateComment.emit(updateModel);
  }

  onDeleteComment(id: string){
    this.deleteComment.emit(id);
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

  isEdit(){
    if (!this.currentComment){
      return false;
    }

    return this.currentComment.id == this.comment.id &&
      this.currentComment.type == this.currentCommentType.edit;
  }

  onShowAttachment(){
    this.blobService.getBlob('comments', this.comment.id).subscribe(f => {
      console.log(f);
      const fileURL = URL.createObjectURL(f);
      window.location.assign(fileURL);
    })
  }
}
