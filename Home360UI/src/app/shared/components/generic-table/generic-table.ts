import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';

export interface UserScreenAccesData {
  [key: string]: any;
  screenCode: string;
    canRead: boolean;
    canCreate: boolean;
    canUpdate: boolean;
    canDeactivate: boolean;
}

@Component({
  selector: 'app-generic-table',
  imports: [CommonModule, FormsModule, MatTableModule],
  templateUrl: './generic-table.html',
  styleUrl: './generic-table.scss',
})
export class GenericTable {
  @Input() columns: any[] = [];
  @Input() data: any[] = [];
  @Input() userAccessData?: UserScreenAccesData;

  @Input() pageSize = 15;
  @Input() currentPage = 1;
  @Input() totalRecords = 0;
  @Input() paginationId = 'generic-table';
  @Input() pageSizeOptions = [15, 20, 50, 100];
  @Input() showPageSizeOption = true;
  @Input() stickyColumn = false;

  @Output() pageChange = new EventEmitter<number>();
  @Output() pageSizeChange = new EventEmitter<number>();
  @Output() action = new EventEmitter<{ type: string; row: any }>();

    get startIndex(): number {

      if (!this.totalRecords) return 0;
      return (this.currentPage - 1) * this.pageSize + 1;
    }

    get endIndex(): number {
      if (!this.totalRecords) return 0;
      const end = this.currentPage * this.pageSize;
      return end > this.totalRecords ? this.totalRecords : end;
    }

    onPageChange(page: number) {
      this.pageChange.emit(page);
    }

    onPageSizeChange(size: number) {
      this.pageSizeChange.emit(size);
    }
}
