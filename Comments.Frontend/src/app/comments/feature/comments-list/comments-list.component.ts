import { Component, OnInit } from '@angular/core';
import { Form } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/auth/data-access/auth.service';
import { CommentModel, CreateCommentModel, CurrentComment, GetCommentsModel, PagedCommentList, UpdateCommentModel } from 'src/app/models/comment';
import { BlobService } from 'src/app/services/blob.service';
import { CommentService } from '../../data-access/comment.service';

@Component({
  selector: 'comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.scss']
})
export class CommentsListComponent implements OnInit {
  comments: CommentModel[] = [];
  pagedList!: PagedCommentList;
  currentComment!: CurrentComment | null;
  userId: string | null = null;
  sortingOptions: string[] = ['None', 'User Name', 'Email', 'Date'];
  sortingOrderOptions: string[] = ['ASC', 'DESC'];
  sortingValue: string = 'None';
  sortingOrder: string = 'DESC';
  getCommentsModel: GetCommentsModel = new GetCommentsModel();
  isAuthenticated: boolean = false;
  commentsLoaded: boolean = false;

  constructor(
    private commentService: CommentService,
    private authService: AuthService,
    private blobService: BlobService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.updateFilterModel();

    this.route.queryParams.subscribe(q => {
      this.sortingValue = q['sort'] ?? 'None';
      this.sortingOrder = q['sortOrder'] ?? 'DESC';
    })

    this.authService.isAuthenticated.subscribe(a => {
      this.isAuthenticated = a;
    })
  }

  updateFilterModel(){
    this.route.queryParams.subscribe(q => {
      this.getCommentsModel.sort = q['sort'];
      this.getCommentsModel.sortOrder = q['sortOrder'];
      this.getCommentsModel.page = q['page'] ?? 1;
      this.getCommentsModel.pageCount = q['pageSize'] ?? 5;
      this.getAllComments();
    })
  }

  getAllComments(){
    this.commentService.getAllComments(this.getCommentsModel).subscribe(c => {
      this.pagedList = c;
      this.comments = c.data;
      console.log(this.pagedList);
      this.commentsLoaded = true;
    })
  }

  onAddComment(model: CreateCommentModel){
    console.log(model.text, model.parentCommentId, model.formData?.get('file'));
    this.commentService.createComment(model).subscribe(c => {
      this.uploadFile(c.id, model.formData);
      this.getAllComments();
      this.currentComment = null;
    });
  }

  onUpdateComment(model: UpdateCommentModel){
    if (model.formData){
      this.uploadFile(model.id, model.formData);
    }

    this.commentService.updateComment(model).subscribe(c => {
      this.getAllComments();
      this.currentComment = null;
    })
  }

  onDeleteComment(id: string){
    this.commentService.deleteComment(id).subscribe(c => {
      this.getAllComments();
      this.currentComment = null;
    })
  }

  onSetCurrentComment(currentComment: CurrentComment | null){
    console.log(currentComment);
    this.currentComment = currentComment;
  }

  getCurrentUserId(){
    this.userId = this.authService.getCurrentUserId();
  }

  uploadFile(id: string, formData: FormData | null){
    if (!formData?.get('file')){
      return;
    }

    this.commentService.uploadAttachment(id, formData).subscribe(_ => {
      this.getAllComments();
    });
  }

  onSort(){
    this.router.navigate([], {
      queryParams:{
        sort: this.sortingValue
      },
      queryParamsHandling: 'merge'
    })
  }

  onChangeSortingOrder(){
    this.router.navigate([], {
      queryParams: {
        sortOrder: this.sortingOrder
      },
      queryParamsHandling: 'merge'
    })
  }
}
