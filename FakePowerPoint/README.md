# 2023F-WindowApplicationDesign

## Course Information

* [Course site](https://woeikaechen.synology.me/wkc/)
* [MS Teams](https://teams.microsoft.com/_#/school/tab::3717002657/19:UQBTqwCJ1X62pNssjICDVAG0ci71wv7JkR1ZapKLNdQ1@thread.tacv2?threadId=19:UQBTqwCJ1X62pNssjICDVAG0ci71wv7JkR1ZapKLNdQ1@thread.tacv2&messageId=classroom&ctx=channel&isTeamLevelApp=true)

## TODO

* [ ] GUI (使用者介面)<br>
  請在界面上方新增一工具列(如圖一所示)。此 Toolbar (在Windows Forms的控制項稱為ToolStrip)應包含三個按鈕：圓形(橢圓形)
  、矩形和線條。
* [x] 增加圓形(橢圓形) 包含繪圖區畫圖以及圖形資料顯示區的UI變更。
* [ ] 圖形繪製 <br>
  當使用者點擊 Toolbar 上的圖形按鈕(選擇圖形)後，即可在繪圖區使用滑鼠左鍵由左 上角拖至右下角畫出一個使用者選擇的圖形，在拖曳過程中，游標保持十字形，被
  繪出的圖形會因游標位置之變更而變更大小，且在放開左鍵後，該圖形會被固定顯 示在繪圖區(如圖二所示)，而游標則恢復為正常的指標形狀、圖形按鈕的
  Checked 屬 性變成 false。同時請注意，當使用者畫出一個圖形後(放開左鍵後)，該圖形的資料 應該同步被顯示到資料顯示區，也就是說，繪圖區與資料顯示區是同一個
  Model 的 兩個 View。
* [x]  使用 DataGridView 新增圖形<br>
  除了使用滑鼠繪圖，使用者也能夠使用圖形資料顯示區進行圖形的繪製以及刪除，當
  使用者按下新增時，請用亂數產生的座標，建立一個新圖形，並同時顯示該圖形的資訊
  在圖形資料顯示區，以及在繪圖區畫出該圖形。
* [ ] Factory Pattern<br>
  在此作業中，有三種形狀（Line, Rectangle, Circle）。當新增形狀時，請使用簡單
  工廠 (simple factory) 模式來創建不同形狀的 Instance。當繼承架構下新增新的形
  狀時，Model 底下只有 Factory class 需要更改，其他的 class 都不用變動。
* [ ] 繼承與多型<br>
  在此作業中，請創建一個基礎類 Shape ，並讓 Line 、 Rectangle 和 Circle 三個
  子類別繼承它並分別覆寫基礎類別中的方法以實現多型。
* [ ]   Presentation Model Pattern
  必須使用 PresentationModel，避免將 view 的邏輯寫在 Form 中，例如 Checked 屬性
  的相關邏輯應該寫在 PresentationModel ，而不是寫在 View 中 。 如未使用
  PresentationModel 則此項無法得分。
* [ ]  Observer pattern<br>
  當 Model (Subject)發生變更時, 應該引用 Observer pattern，以”事件”通知 View
  (Observer)，使得 View (繪圖區及圖形資料顯示區)能更新其畫面，並且維持 View 與
  Model 的單向關係。
* [ ]  Model View Controller (MVC) Pattern<br>
  你的設計將根據 MVC 架構評分，請讓 UI 盡可能薄，並必須將 UI 以及 Model 切
  開，強制實行單向依賴，建議遵循「圖三」的 Class Diagram 設計程式。
* [ ]  Code Quality<br>
  請使用 Dr.Smell 檢查你的程式，Code Quality 將取決於你的程式碼是否有 bad smell，
  你的分數將取決於你的 code smell 密度。當你使用 Windows Form Designer 產生程
  式碼時，其預設的變數命名、副程式命名等可能違反 coding standard，請修改以符合
  本課程之規定。
