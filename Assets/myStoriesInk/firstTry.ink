VAR rebirths = 0

-> start

=== start ===
帝國再次崛起，這是你第{rebirths + 1}次重生。
你是這個帝國的統治者，面對當前的局勢，你會如何應對？

* [全力發展經濟] -> economic_focus
* [擴大軍事實力] -> military_focus
* [加強宗教信仰] -> religious_focus

=== economic_focus ===
你選擇專注於經濟發展。人民逐漸富裕，但也引發了新的問題。你會如何應對？
* [提高稅收以維持發展] -> raise_taxes
* [減少稅收，鼓勵自由貿易] -> lower_taxes

=== military_focus ===
你決定擴大軍事實力。你的帝國變得更強大，但戰爭的陰影隨之而來。你將如何處理？
* [繼續擴張，擊敗所有敵人] -> continue_war
* [與鄰國簽訂和平條約] -> peace_treaty

=== religious_focus ===
你選擇加強宗教信仰。天主教的影響力在帝國內部不斷增強。你會如何平衡宗教與政權的關係？
* [賦予宗教更多權力] -> empower_religion
* [限制宗教的影響] -> restrict_religion

=== raise_taxes ===
你提高了稅收，雖然短期內增加了收入，但民眾的怨言開始增加。
* [安撫民眾] -> pacify_people
* [繼續高壓統治] -> oppression

=== lower_taxes ===
你選擇減少稅收，經濟更加繁榮，但你的軍事和宗教力量開始衰弱。
-> second_rebirth

=== continue_war ===
你發動了幾場戰爭，雖然取得了勝利，但帝國資源幾乎耗盡。
* [暫停戰爭，重整旗鼓] -> cease_war
* [繼續侵略直到勝利] -> endless_war

=== peace_treaty ===
你選擇與鄰國簽訂和平條約，避免了戰爭，但一些將軍感到不滿，開始策劃叛亂。
* [鎮壓叛亂] -> suppress_rebellion
* [談判解決] -> negotiate_rebellion

=== empower_religion ===
天主教在你的帝國中變得極為強大，甚至開始影響國家決策。你能否控制住局面？
* [接受宗教統治] -> religious_rule
* [試圖反擊，恢復政權] -> restore_power

=== restrict_religion ===
你限制了宗教權力，教會影響減弱，但民眾對你的信任也隨之減少。
-> second_rebirth

=== pacify_people ===
你試圖安撫民眾，雖然暫時穩定了局勢，但潛在的不滿仍然存在。
-> second_rebirth

=== oppression ===
你選擇以強硬的手段統治，民眾的反抗逐漸加劇。最終，帝國陷入了內亂。
-> second_rebirth

=== cease_war ===
你暫停了戰爭，重整旗鼓以待機會。然而，資源短缺和軍隊士氣低落成為了你的主要挑戰。
-> second_rebirth

=== endless_war ===
你決定不顧一切繼續侵略。雖然你取得了許多勝利，但帝國最終因資源耗盡而崩潰。
-> second_rebirth

=== suppress_rebellion ===
你成功鎮壓了叛亂，但這也削弱了你的軍隊和國內的支持。
-> second_rebirth

=== negotiate_rebellion ===
你通過談判成功平息了叛亂，但這讓一些將軍對你的領導能力產生了懷疑。
-> second_rebirth

=== religious_rule ===
你接受了宗教的統治，最終成為了宗教的傀儡。帝國的世俗權力逐漸消失。
-> second_rebirth

=== restore_power ===
你試圖恢復政權，但宗教的力量已經根深蒂固。你陷入了無盡的內鬥中。
-> second_rebirth

=== second_rebirth ===
~ rebirths = rebirths + 1
這是你第{rebirths}次重生。面對這次重生，你會採取什麼策略？
* [回歸經濟發展] -> economic_focus
* [全力增強軍事] -> military_focus
* [宗教信仰為主] -> religious_focus
