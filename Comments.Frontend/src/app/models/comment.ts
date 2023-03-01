export class CommentModel{
  id!: string;
  userName!: string;
  text!: string;
  hasAttachment!: boolean;
  createdAt!: Date;
  parentCommentId!: string;
  replies!: CommentModel[];
}

export class CreateCommentModel{
  text!: string;
  parentCommentId: string | undefined;
  formData!: FormData | null;
}

export class CommentSubmitModel{
  text!: string;
  formData!: FormData | null;
}

export class CurrentComment{
  id!: string;
  type!: CurrentCommentType;
}

export enum CurrentCommentType{
  reply,
  edit
}

export class PagedCommentList{
  data!: CommentModel[];
  page!: number;
  pageCount!: number;
}

export class GetCommentsModel{
  sort!: string;
  sortOrder!: string;
  page!: number;
  pageCount!: number;
}
