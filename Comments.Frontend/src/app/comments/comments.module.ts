import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentItemComponent } from './feature/comment-item/comment-item.component';
import { CommentsListComponent } from './feature/comments-list/comments-list.component';
import { CommentFormComponent } from './feature/comment-form/comment-form.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { QuillModule } from 'ngx-quill';
import { RecaptchaModule } from 'ng-recaptcha';
import { PagingWrapperComponent } from './utilities/paging-wrapper/paging-wrapper.component';

@NgModule({
  declarations: [
    CommentsListComponent,
    CommentItemComponent,
    CommentFormComponent,
    PagingWrapperComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    QuillModule,
    RecaptchaModule,
    FormsModule
  ]
})
export class CommentsModule { }
