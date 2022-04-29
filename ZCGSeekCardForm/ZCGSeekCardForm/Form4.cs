﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZCGSeekCardForm
{
    public partial class Form4 : Form
    {
        public Form4(string ScriptText)
        {
            InitializeComponent();
            richTextBox1.Text = ScriptText;
        }
        public Form4()
        {
            InitializeComponent();

        }
       //改变文本颜色
        private void ChangeKeyColor(string key, Color color)
        {
            Regex regex = new Regex(key);
            //找出内容中所有的要替换的关键字
            MatchCollection collection = regex.Matches(richTextBox1.Text);
            if (collection == null) return;
            //对所有的要替换颜色的关键字逐个替换颜色
            foreach (Match match in collection)
            {
                //开始位置、长度、颜色缺一不可
                richTextBox1.SelectionStart = match.Index;
                richTextBox1.SelectionLength = key.Length;
                richTextBox1.SelectionColor = color;
            }
            collection = null;
            regex = null;
        }
        //改变颜色
        private  void ChangeKeyColor(List<string> list, Color color)
        {
            foreach (string str in list)
            {
                ChangeKeyColor(str, color);
            }
        }
        //改变字体
        private void ChangeFont()
        {
            string path2 = @".\Font\思源宋体 SC-Bold.otf";
            using (Font font = NewFont.FontSet(path2, 9, FontStyle.Regular))
            {
                this.richTextBox1.Font = font;
                font.Dispose();
            }
        }
        #region 字体颜色
        private void ChangeColor()
        {
            //列注释不为空时，改变列注释颜色

            //lua关键字
            ChangeKeyColor("and ", Color.DeepSkyBlue);
            ChangeKeyColor("break ", Color.DeepSkyBlue);
            ChangeKeyColor("do ", Color.DeepSkyBlue);
            ChangeKeyColor("else ", Color.DeepSkyBlue);
            ChangeKeyColor("elseif ", Color.DeepSkyBlue);
            ChangeKeyColor("end", Color.DeepSkyBlue);
            ChangeKeyColor("false ", Color.DeepSkyBlue);
            ChangeKeyColor("for ", Color.DeepSkyBlue);
            ChangeKeyColor("function ", Color.DeepSkyBlue);
            ChangeKeyColor("if ", Color.DeepSkyBlue);
            ChangeKeyColor("in ", Color.DeepSkyBlue);
            ChangeKeyColor("local ", Color.DeepSkyBlue);
            ChangeKeyColor("nil", Color.DeepSkyBlue);
            ChangeKeyColor(" not ", Color.DeepSkyBlue);
            ChangeKeyColor("or ", Color.DeepSkyBlue);
            ChangeKeyColor("repeat ", Color.DeepSkyBlue);
            ChangeKeyColor("return ", Color.DeepSkyBlue);
            ChangeKeyColor("then ", Color.DeepSkyBlue);
            ChangeKeyColor("true ", Color.DeepSkyBlue);
            ChangeKeyColor("until ", Color.DeepSkyBlue);
            ChangeKeyColor("while ", Color.DeepSkyBlue);

            //ygo 函数
            ChangeKeyColor(" c:", Color.LimeGreen);
            ChangeKeyColor(" e:", Color.LimeGreen);
            ChangeKeyColor("e:", Color.LimeGreen);
            ChangeKeyColor("tc:", Color.LimeGreen);
            ChangeKeyColor(" c ", Color.LimeGreen);
            ChangeKeyColor("tc ", Color.LimeGreen);
            ChangeKeyColor("te:", Color.LimeGreen);
            ChangeKeyColor("re:", Color.LimeGreen);
            ChangeKeyColor("rp:", Color.LimeGreen);
            ChangeKeyColor("g:", Color.LimeGreen);
            ChangeKeyColor("mg:", Color.LimeGreen);
            ChangeKeyColor("tg:", Color.LimeGreen);
            ChangeKeyColor("exg:", Color.LimeGreen);
            ChangeKeyColor("xyzg:", Color.LimeGreen);
            ChangeKeyColor("sg:", Color.LimeGreen);
            ChangeKeyColor("Card.", Color.LimeGreen);

            ChangeKeyColor("GetCode", Color.LimeGreen);
            ChangeKeyColor("GetOriginalCode", Color.LimeGreen);
            ChangeKeyColor("GetOriginalCodeRule", Color.LimeGreen);
            ChangeKeyColor("GetFusionCode", Color.LimeGreen);
            ChangeKeyColor("IsFusionCode", Color.LimeGreen);
            ChangeKeyColor("IsSetCard", Color.LimeGreen);
            ChangeKeyColor("IsOriginalSetCard", Color.LimeGreen);
            ChangeKeyColor("IsPreviousSetCard", Color.LimeGreen);
            ChangeKeyColor("IsFusionSetCard", Color.LimeGreen);
            ChangeKeyColor("GetType", Color.LimeGreen);
            ChangeKeyColor("GetOriginalType", Color.LimeGreen);
            ChangeKeyColor("GetFusionType", Color.LimeGreen);
            ChangeKeyColor("GetSynchroType", Color.LimeGreen);
            ChangeKeyColor("GetXyzType", Color.LimeGreen);
            ChangeKeyColor("GetLevel", Color.LimeGreen);
            ChangeKeyColor("GetRank", Color.LimeGreen);
            ChangeKeyColor("GetLink", Color.LimeGreen);
            ChangeKeyColor("GetSynchroLevel", Color.LimeGreen);
            ChangeKeyColor("GetRitualLevel", Color.LimeGreen);
            ChangeKeyColor("GetOriginalLevel", Color.LimeGreen);
            ChangeKeyColor("GetOriginalRank", Color.LimeGreen);
            ChangeKeyColor("IsXyzLevel", Color.LimeGreen);
            ChangeKeyColor("GetLeftScale", Color.LimeGreen);
            ChangeKeyColor("GetOriginalLeftScale", Color.LimeGreen);
            ChangeKeyColor("GetRightScale", Color.LimeGreen);
            ChangeKeyColor("GetOriginalRightScale", Color.LimeGreen);
            ChangeKeyColor("GetCurrentScale", Color.LimeGreen);
            ChangeKeyColor("GetAttribute", Color.LimeGreen);
            ChangeKeyColor("GetOriginalAttribute", Color.LimeGreen);
            ChangeKeyColor("GetFusionAttribute", Color.LimeGreen);
            ChangeKeyColor("GetRace", Color.LimeGreen);
            ChangeKeyColor("GetOriginalRace", Color.LimeGreen);
            ChangeKeyColor("GetAttack", Color.LimeGreen);
            ChangeKeyColor("GetBaseAttack", Color.LimeGreen);
            ChangeKeyColor("GetTextAttack", Color.LimeGreen);
            ChangeKeyColor("GetDefense", Color.LimeGreen);
            ChangeKeyColor("IsPublic", Color.LimeGreen);
            ChangeKeyColor("GetBaseDefense", Color.LimeGreen);
            ChangeKeyColor("GetTextDefense", Color.LimeGreen);
            ChangeKeyColor("GetPreviousCodeOnField", Color.LimeGreen);
            ChangeKeyColor("GetPreviousTypeOnField", Color.LimeGreen);
            ChangeKeyColor("GetPreviousLevelOnField", Color.LimeGreen);
            ChangeKeyColor("GetPreviousRankOnField", Color.LimeGreen);
            ChangeKeyColor("GetPreviousAttributeOnField", Color.LimeGreen);
            ChangeKeyColor("GetPreviousRaceOnField", Color.LimeGreen);
            ChangeKeyColor("GetPreviousAttackOnField", Color.LimeGreen);
            ChangeKeyColor("GetPreviousDefenseOnField", Color.LimeGreen);
            ChangeKeyColor("GetOwner", Color.LimeGreen);
            ChangeKeyColor("GetControler", Color.LimeGreen);
            ChangeKeyColor("GetPreviousControler", Color.LimeGreen);
            ChangeKeyColor("GetReason", Color.LimeGreen);
            ChangeKeyColor("GetReasonCard", Color.LimeGreen);
            ChangeKeyColor("GetReasonPlayer", Color.LimeGreen);
            ChangeKeyColor("GetReasonEffect", Color.LimeGreen);
            ChangeKeyColor("GetPosition", Color.LimeGreen);
            ChangeKeyColor("GetHandler", Color.LimeGreen);
            ChangeKeyColor("GetPreviousPosition", Color.LimeGreen);
            ChangeKeyColor("GetBattlePosition", Color.LimeGreen);
            ChangeKeyColor("GetLocation", Color.LimeGreen);
            ChangeKeyColor("GetPreviousLocation", Color.LimeGreen);
            ChangeKeyColor("GetSequence", Color.LimeGreen);
            ChangeKeyColor("GetPreviousSequence", Color.LimeGreen);
            ChangeKeyColor("GetSummonType", Color.LimeGreen);
            ChangeKeyColor("GetSummonLocation", Color.LimeGreen);
            ChangeKeyColor("GetTurnID", Color.LimeGreen);
            ChangeKeyColor("IsOriginalCodeRule", Color.LimeGreen);
            ChangeKeyColor("IsCode", Color.LimeGreen);
            ChangeKeyColor("IsType", Color.LimeGreen);
            ChangeKeyColor("IsFusionType", Color.LimeGreen);
            ChangeKeyColor("IsXyzType", Color.LimeGreen);
            ChangeKeyColor("IsLevel", Color.LimeGreen);
            ChangeKeyColor("IsRank", Color.LimeGreen);
            ChangeKeyColor("IsAttack", Color.LimeGreen);
            ChangeKeyColor("IsDefense", Color.LimeGreen);
            ChangeKeyColor("IsRace", Color.LimeGreen);
            ChangeKeyColor("IsAttribute", Color.LimeGreen);
            ChangeKeyColor("IsFusionAttribute", Color.LimeGreen);
            ChangeKeyColor("IsReason", Color.LimeGreen);
            ChangeKeyColor("IsSummonLocation", Color.LimeGreen);
            ChangeKeyColor("IsSummonPlayer", Color.LimeGreen);
            ChangeKeyColor("IsStatus", Color.LimeGreen);
            ChangeKeyColor("SetTurnCounter", Color.LimeGreen);
            ChangeKeyColor("GetTurnCounter", Color.LimeGreen);
            ChangeKeyColor("GetEquipGroup", Color.LimeGreen);
            ChangeKeyColor("GetEquipCount", Color.LimeGreen);
            ChangeKeyColor("GetEquipTarget", Color.LimeGreen);
            ChangeKeyColor("GetPreviousEquipTarget", Color.LimeGreen);
            ChangeKeyColor("GetOverlayGroup", Color.LimeGreen);
            ChangeKeyColor("GetOverlayCount", Color.LimeGreen);
            ChangeKeyColor("GetOverlayTarget", Color.LimeGreen);
            ChangeKeyColor("GetBattledGroup", Color.LimeGreen);
            ChangeKeyColor("GetAttackAnnouncedCount", Color.LimeGreen);
            ChangeKeyColor("RegisterEffect", Color.LimeGreen);
            ChangeKeyColor("ResetEffect", Color.LimeGreen);
            ChangeKeyColor("GetEffectCount", Color.LimeGreen);
            ChangeKeyColor("RegisterFlagEffect", Color.LimeGreen);
            ChangeKeyColor("ResetFlagEffect", Color.LimeGreen);
            ChangeKeyColor("IsRelateToEffect", Color.LimeGreen);
            ChangeKeyColor("IsRelateToBattle", Color.LimeGreen);
            ChangeKeyColor("CopyEffect", Color.LimeGreen);
            ChangeKeyColor("ReplaceEffect", Color.LimeGreen);
            ChangeKeyColor("EnableReviveLimit", Color.LimeGreen);
            ChangeKeyColor("CompleteProcedure", Color.LimeGreen);
            ChangeKeyColor("IsSummonableCard", Color.LimeGreen);
            ChangeKeyColor("IsSpecialSummonable", Color.LimeGreen);
            ChangeKeyColor("IsXyzSummonable", Color.LimeGreen);
            ChangeKeyColor("IsCanBeSpecialSummoned", Color.LimeGreen);
            ChangeKeyColor("IsAbleToHand", Color.LimeGreen);
            ChangeKeyColor("IsAbleToDeck", Color.LimeGreen);
            ChangeKeyColor("IsAbleToExtra", Color.LimeGreen);
            ChangeKeyColor("IsAbleToGrave", Color.LimeGreen);
            ChangeKeyColor("IsAbleToHandAsCost", Color.LimeGreen);
            ChangeKeyColor("IsAbleToDeckAsCost", Color.LimeGreen);
            ChangeKeyColor("IsAbleToExtraAsCost", Color.LimeGreen);
            ChangeKeyColor("IsAbleToDeckOrExtraAsCost", Color.LimeGreen);
            ChangeKeyColor("IsAbleToGraveAsCost", Color.LimeGreen);
            ChangeKeyColor("IsAbleToRemoveAsCost", Color.LimeGreen);
            ChangeKeyColor("IsReleasable", Color.LimeGreen);
            ChangeKeyColor("IsDiscardable", Color.LimeGreen);
            ChangeKeyColor("IsFaceup", Color.LimeGreen);
            ChangeKeyColor("IsAttackPos", Color.LimeGreen);
            ChangeKeyColor("IsFacedown", Color.LimeGreen);
            ChangeKeyColor("IsDefensePos", Color.LimeGreen);
            ChangeKeyColor("IsPosition", Color.LimeGreen);
            ChangeKeyColor("IsPreviousPosition", Color.LimeGreen);
            ChangeKeyColor("IsControler", Color.LimeGreen);
            ChangeKeyColor("IsPreviousControler", Color.LimeGreen);
            ChangeKeyColor("IsOnField", Color.LimeGreen);
            ChangeKeyColor("IsLocation", Color.LimeGreen);
            ChangeKeyColor("IsPreviousLocation", Color.LimeGreen);
            ChangeKeyColor("IsLevelBelow", Color.LimeGreen);
            ChangeKeyColor("IsLevelAbove", Color.LimeGreen);
            ChangeKeyColor("IsRankBelow", Color.LimeGreen);
            ChangeKeyColor("IsRankAbove", Color.LimeGreen);
            ChangeKeyColor("IsAttackBelow", Color.LimeGreen);
            ChangeKeyColor("IsAttackAbove", Color.LimeGreen);
            ChangeKeyColor("IsDefenseBelow", Color.LimeGreen);
            ChangeKeyColor("IsDefenseAbove", Color.LimeGreen);
            ChangeKeyColor("IsAbleToChangeControler", Color.LimeGreen);
            ChangeKeyColor("IsControlerCanBeChanged", Color.LimeGreen);
            ChangeKeyColor("IsCanBeEffectTarget", Color.LimeGreen);
            ChangeKeyColor("AddCounter", Color.LimeGreen);
            ChangeKeyColor("RemoveCounter", Color.LimeGreen);
            ChangeKeyColor("GetCounter", Color.LimeGreen);
            ChangeKeyColor("SetCounterLimit", Color.LimeGreen);
            ChangeKeyColor("IsCanOverlay", Color.LimeGreen);
            ChangeKeyColor("CancelToGrave", Color.LimeGreen);
            ChangeKeyColor("SetHint", Color.LimeGreen);
            ChangeKeyColor("CreateEffect", Color.LimeGreen);
            ChangeKeyColor("GlobalEffect", Color.LimeGreen);
            ChangeKeyColor("Clone", Color.LimeGreen);
            ChangeKeyColor("Reset", Color.LimeGreen);
            ChangeKeyColor("SetDescription", Color.LimeGreen);
            ChangeKeyColor("SetCode", Color.LimeGreen);
            ChangeKeyColor("SetRange", Color.LimeGreen);
            ChangeKeyColor("SetTargetRange", Color.LimeGreen);
            ChangeKeyColor("SetCountLimit", Color.LimeGreen);
            ChangeKeyColor("SetReset", Color.LimeGreen);
            ChangeKeyColor("SetProperty", Color.LimeGreen);
            ChangeKeyColor("SetLabel", Color.LimeGreen);
            ChangeKeyColor("SetLabelObject", Color.LimeGreen);
            ChangeKeyColor("SetCategory", Color.LimeGreen);
            ChangeKeyColor("SetHintTiming", Color.LimeGreen);
            ChangeKeyColor("SetCondition", Color.LimeGreen);
            ChangeKeyColor("SetCost", Color.LimeGreen);
            ChangeKeyColor("SetTarget", Color.LimeGreen);
            ChangeKeyColor("SetValue", Color.LimeGreen);
            ChangeKeyColor("SetOperation", Color.LimeGreen);
            ChangeKeyColor("SetOwnerPlayer", Color.LimeGreen);
            ChangeKeyColor("GetCode", Color.LimeGreen);
            ChangeKeyColor("GetType", Color.LimeGreen);
            ChangeKeyColor("GetLabel", Color.LimeGreen);
            ChangeKeyColor("GetOwner", Color.LimeGreen);
            ChangeKeyColor("GetActiveType", Color.LimeGreen);
            ChangeKeyColor("IsActiveType", Color.LimeGreen);
            ChangeKeyColor("IsHasType", Color.LimeGreen);
            ChangeKeyColor("IsChainNegatable", Color.LimeGreen);
            ChangeKeyColor("IsSummonType", Color.LimeGreen);
            ChangeKeyColor("IsHasCategory", Color.LimeGreen);
            ChangeKeyColor("SetProperty", Color.LimeGreen);
            ChangeKeyColor("SetLabel", Color.LimeGreen);
            ChangeKeyColor("SetLabelObject", Color.LimeGreen);
            ChangeKeyColor("CreateGroup", Color.LimeGreen);
            ChangeKeyColor("KeepAlive", Color.LimeGreen);
            ChangeKeyColor("DeleteGroup", Color.LimeGreen);
            ChangeKeyColor("XyzSummon", Color.LimeGreen);
            ChangeKeyColor("AddCard", Color.LimeGreen);
            ChangeKeyColor("GetFirst", Color.LimeGreen);
            ChangeKeyColor("GetNext", Color.LimeGreen);
            ChangeKeyColor("GetCount", Color.LimeGreen);
            ChangeKeyColor("Filter", Color.LimeGreen);
            ChangeKeyColor("FilterCount", Color.LimeGreen);
            ChangeKeyColor("Select", Color.LimeGreen);
            ChangeKeyColor("RandomSelect", Color.LimeGreen);
            ChangeKeyColor("IsExists", Color.LimeGreen);
            ChangeKeyColor("GetMinGroup", Color.LimeGreen);
            ChangeKeyColor("GetMaxGroup", Color.LimeGreen);
            ChangeKeyColor("GetSum", Color.LimeGreen);
            ChangeKeyColor("GetClassCount", Color.LimeGreen);
            ChangeKeyColor("Remove", Color.LimeGreen);
            ChangeKeyColor("Merge", Color.LimeGreen);
            ChangeKeyColor("Duel.GetLP", Color.LimeGreen);
            ChangeKeyColor("Duel.SetLP", Color.LimeGreen);
            ChangeKeyColor("Duel.GetTurnPlayer", Color.LimeGreen);
            ChangeKeyColor("Duel.GetTurnCount", Color.LimeGreen);
            ChangeKeyColor("Duel.GetDrawCount", Color.LimeGreen);
            ChangeKeyColor("Duel.RegisterEffect", Color.LimeGreen);
            ChangeKeyColor("Duel.RegisterFlagEffect", Color.LimeGreen);
            ChangeKeyColor("Duel.GetFlagEffect", Color.LimeGreen);
            ChangeKeyColor("Duel.ResetFlagEffect", Color.LimeGreen);
            ChangeKeyColor("Duel.Destroy", Color.LimeGreen);
            ChangeKeyColor("Duel.Remove", Color.LimeGreen);
            ChangeKeyColor("Duel.SendtoGrave", Color.LimeGreen);
            ChangeKeyColor("Duel.SendtoHand", Color.LimeGreen);
            ChangeKeyColor("Duel.SendtoDeck", Color.LimeGreen);
            ChangeKeyColor("Duel.GetOperatedGroup", Color.LimeGreen);
            ChangeKeyColor("Duel.Summon", Color.LimeGreen);
            ChangeKeyColor("GetSum", Color.LimeGreen);
            ChangeKeyColor("Duel.SpecialSummonRule", Color.LimeGreen);
            ChangeKeyColor("Duel.SSet", Color.LimeGreen);
            ChangeKeyColor("Duel.CreateToken", Color.LimeGreen);
            ChangeKeyColor("Duel.SpecialSummon", Color.LimeGreen);
            ChangeKeyColor("Duel.SpecialSummonStep", Color.LimeGreen);
            ChangeKeyColor("Duel.SpecialSummonComplete", Color.LimeGreen);
            ChangeKeyColor("Duel.IsCanAddCounter", Color.LimeGreen);
            ChangeKeyColor("Duel.RemoveCounter", Color.LimeGreen);
            ChangeKeyColor("Duel.IsCanRemoveCounter", Color.LimeGreen);
            ChangeKeyColor("Duel.GetCounter", Color.LimeGreen);
            ChangeKeyColor("Duel.MoveToField", Color.LimeGreen);
            ChangeKeyColor("Duel.ReturnToField", Color.LimeGreen);
            ChangeKeyColor("Duel.SetChainLimit", Color.LimeGreen);
            ChangeKeyColor("Duel.Win", Color.LimeGreen);
            ChangeKeyColor("Duel.Draw", Color.LimeGreen);
            ChangeKeyColor("Duel.Damage", Color.LimeGreen);
            ChangeKeyColor("Duel.Recover", Color.LimeGreen);
            ChangeKeyColor("Duel.Equip", Color.LimeGreen);
            ChangeKeyColor("Duel.EquipComplete", Color.LimeGreen);
            ChangeKeyColor("Duel.GetControl", Color.LimeGreen);
            ChangeKeyColor("Duel.CheckLPCost", Color.LimeGreen);
            ChangeKeyColor("Duel.PayLPCost", Color.LimeGreen);
            ChangeKeyColor("Duel.DiscardDeck", Color.LimeGreen);
            ChangeKeyColor("Duel.DiscardHand", Color.LimeGreen);
            ChangeKeyColor("Duel.ShuffleDeck", Color.LimeGreen);
            ChangeKeyColor("Duel.IsPlayerAffectedByEffect", Color.LimeGreen);
            ChangeKeyColor("Duel.SetOperationInfo", Color.LimeGreen);
            ChangeKeyColor("Duel.ShuffleHand", Color.LimeGreen);
            ChangeKeyColor("Duel.NegateActivation", Color.LimeGreen);
            ChangeKeyColor("Duel.NegateEffect", Color.LimeGreen);
            ChangeKeyColor("Duel.GetLocationCount", Color.LimeGreen);
            ChangeKeyColor("Duel.GetFieldCard", Color.LimeGreen);
            ChangeKeyColor("Duel.GetCurrentChain", Color.LimeGreen);
            ChangeKeyColor("Duel.CheckLocation", Color.LimeGreen);
            ChangeKeyColor("Duel.GetChainInfo", Color.LimeGreen);
            ChangeKeyColor("Duel.GetCurrentPhase", Color.LimeGreen);
            ChangeKeyColor("Duel.SkipPhase", Color.LimeGreen);
            ChangeKeyColor("Duel.NegateAttack", Color.LimeGreen);
            ChangeKeyColor("Duel.GetMatchingGroup", Color.LimeGreen);
            ChangeKeyColor("Duel.GetMatchingGroupCount", Color.LimeGreen);
            ChangeKeyColor("Duel.GetFirstMatchingCard", Color.LimeGreen);
            ChangeKeyColor("Duel.IsExistingMatchingCard", Color.LimeGreen);
            ChangeKeyColor("Duel.SelectMatchingCard", Color.LimeGreen);
            ChangeKeyColor("Duel.GetReleaseGroup", Color.LimeGreen);
            ChangeKeyColor("Duel.GetReleaseGroupCount", Color.LimeGreen);
            ChangeKeyColor("Duel.SelectTarget", Color.LimeGreen);
            ChangeKeyColor("Duel.Overlay", Color.LimeGreen);
            ChangeKeyColor("Duel.IsExistingTarget", Color.LimeGreen);
            ChangeKeyColor("Duel.GetOverlayGroup", Color.LimeGreen);
            ChangeKeyColor("Duel.GetOverlayCount", Color.LimeGreen);
            ChangeKeyColor("Duel.RemoveOverlayCard", Color.LimeGreen);
            ChangeKeyColor("Duel.CheckRemoveOverlayCard", Color.LimeGreen);
            ChangeKeyColor("Duel.Hint", Color.LimeGreen);
            ChangeKeyColor("Duel.SelectOption", Color.LimeGreen);
            ChangeKeyColor("Duel.SelectYesNo", Color.LimeGreen);
            ChangeKeyColor("Duel.AnnounceRace", Color.LimeGreen);
            ChangeKeyColor("Duel.AnnounceLevel", Color.LimeGreen);
            ChangeKeyColor("Duel.AnnounceAttribute", Color.LimeGreen);
            ChangeKeyColor("Duel.AnnounceCard", Color.LimeGreen);
            ChangeKeyColor("Duel.AnnounceType", Color.LimeGreen);
            ChangeKeyColor("Duel.AnnounceNumber", Color.LimeGreen);
            ChangeKeyColor("Duel.AnnounceCoin", Color.LimeGreen);
            ChangeKeyColor("Duel.TossCoin", Color.LimeGreen);
            ChangeKeyColor("Duel.TossDice", Color.LimeGreen);
            ChangeKeyColor("Effect.", Color.LimeGreen);
            ChangeKeyColor("SetType", Color.LimeGreen);
            ChangeKeyColor("Duel", Color.LimeGreen);
            for (int num = 0; num < 11; num++)
            {
                ChangeKeyColor("e"+ num+":", Color.LimeGreen);
            }

            ChangeKeyColor("EFFECT_CODES", Color.Khaki);
            ChangeKeyColor("LOCATION_DECK", Color.Khaki);
            ChangeKeyColor("LOCATION_HAND", Color.Khaki);
            ChangeKeyColor("LOCATION_MZONE", Color.Khaki);
            ChangeKeyColor("LOCATION_SZONE", Color.Khaki);
            ChangeKeyColor("LOCATION_GRAVE", Color.Khaki);
            ChangeKeyColor("LOCATION_REMOVED", Color.Khaki);
            ChangeKeyColor("LOCATION_EXTRA", Color.Khaki);
            ChangeKeyColor("LOCATION_OVERLAY", Color.Khaki);
            ChangeKeyColor("LOCATION_ONFIELD", Color.Khaki);
            ChangeKeyColor("LOCATION_FZONE", Color.Khaki);
            ChangeKeyColor("LOCATION_PZONE", Color.Khaki);
            ChangeKeyColor("EFFECT_CODES", Color.Khaki);
            ChangeKeyColor("EFFECT_IMMUNE_EFFECT", Color.Khaki);
            ChangeKeyColor("EFFECT_DISABLE", Color.Khaki);
            ChangeKeyColor("EFFECT_DISABLE_EFFECT", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DISABLE", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_INACTIVATE	", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DISEFFECT", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_CONTROL", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_CHANGE_CONTROL", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_ACTIVATE", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_TRIGGER", Color.Khaki);
            ChangeKeyColor("EFFECT_DISABLE_TRAPMONSTER", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_CHANGE_POSITION", Color.Khaki);
            ChangeKeyColor("EFFECT_TRAP_ACT_IN_HAND", Color.Khaki);
            ChangeKeyColor("EFFECT_TRAP_ACT_IN_SET_TURN", Color.Khaki);
            ChangeKeyColor("EFFECT_REMAIN_FIELD", Color.Khaki);
            ChangeKeyColor("EFFECT_MONSTER_SSET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_SUMMON", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_FLIP_SUMMON", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_SPECIAL_SUMMON", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_MSET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_SSET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DRAW", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DISABLE_SUMMON", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DISABLE_SPSUMMON", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_SUMMON_COUNT_LIMIT", Color.Khaki);
            ChangeKeyColor("EFFECT_IMMUNE_EFFECT", Color.Khaki);
            ChangeKeyColor("EFFECT_EXTRA_SUMMON_COUNT", Color.Khaki);
            ChangeKeyColor("EFFECT_SPSUMMON_CONDITION", Color.Khaki);
            ChangeKeyColor("EFFECT_REVIVE_LIMIT", Color.Khaki);
            ChangeKeyColor("EFFECT_SUMMON_PROC	", Color.Khaki);
            ChangeKeyColor("EFFECT_LIMIT_SUMMON_PROC", Color.Khaki);
            ChangeKeyColor("EFFECT_SPSUMMON_PROC_G	", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_PROC", Color.Khaki);
            ChangeKeyColor("EFFECT_LIMIT_SET_PROC", Color.Khaki);
            ChangeKeyColor("EFFECT_SPSUMMON_PROC", Color.Khaki);
            ChangeKeyColor("EFFECT_EXTRA_SET_COUNT", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DISABLE_FLIP_SUMMON", Color.Khaki);
            ChangeKeyColor("EFFECT_INDESTRUCTABLE", Color.Khaki);
            ChangeKeyColor("EFFECT_INDESTRUCTABLE_EFFECT", Color.Khaki);
            ChangeKeyColor("EFFECT_INDESTRUCTABLE_BATTLE", Color.Khaki);
            ChangeKeyColor("EFFECT_UNRELEASABLE_SUM", Color.Khaki);
            ChangeKeyColor("EFFECT_UNRELEASABLE_NONSUM", Color.Khaki);
            ChangeKeyColor("EFFECT_DESTROY_SUBSTITUTE", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_RELEASE", Color.Khaki);
            ChangeKeyColor("EFFECT_INDESTRUCTABLE_COUNT", Color.Khaki);
            ChangeKeyColor("EFFECT_UNRELEASABLE_EFFECT", Color.Khaki);
            ChangeKeyColor("EFFECT_DESTROY_REPLACE", Color.Khaki);
            ChangeKeyColor("EFFECT_RELEASE_REPLACE", Color.Khaki);
            ChangeKeyColor("EFFECT_SEND_REPLACE", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DISCARD_HAND", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DISCARD_DECK", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_USE_AS_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_PLACE_COUNTER", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_TO_GRAVE_AS_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_LEAVE_FIELD_REDIRECT", Color.Khaki);
            ChangeKeyColor("EFFECT_TO_HAND_REDIRECT", Color.Khaki);
            ChangeKeyColor("EFFECT_TO_DECK_REDIRECT", Color.Khaki);
            ChangeKeyColor("EFFECT_TO_GRAVE_REDIRECT", Color.Khaki);
            ChangeKeyColor("EFFECT_TO_GRAVE_REDIRECT_CB", Color.Khaki);
            ChangeKeyColor("EFFECT_REMOVE_REDIRECT", Color.Khaki);
            ChangeKeyColor("EFFECT_BATTLE_DESTROY_REDIRECT", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_TO_HAND", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_TO_DECK", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_REMOVE", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_TO_GRAVE", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_TURN_SET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_BE_BATTLE_TARGET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_BE_EFFECT_TARGET", Color.Khaki);
            ChangeKeyColor("EFFECT_IGNORE_BATTLE_TARGET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_SELECT_BATTLE_TARGET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_SELECT_EFFECT_TARGET", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_DIRECT_ATTACK", Color.Khaki);
            ChangeKeyColor("EFFECT_DIRECT_ATTACK", Color.Khaki);
            ChangeKeyColor("EFFECT_DUAL_STATUS", Color.Khaki);
            ChangeKeyColor("EFFECT_EQUIP_LIMIT", Color.Khaki);
            ChangeKeyColor("EFFECT_DUAL_SUMMONABLE", Color.Khaki);
            ChangeKeyColor("EFFECT_REVERSE_DAMAGE", Color.Khaki);
            ChangeKeyColor("EFFECT_REVERSE_RECOVER", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_DAMAGE", Color.Khaki);
            ChangeKeyColor("EFFECT_REFLECT_DAMAGE", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_ATTACK", Color.Khaki);
            ChangeKeyColor("EFFECT_CANNOT_CHANGE_POS_E", Color.Khaki);
            ChangeKeyColor("EFFECT_ACTIVATE_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_SUMMON_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_SPSUMMON_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_FLIPSUMMON_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_MSET_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_SSET_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_ATTACK_COST", Color.Khaki);
            ChangeKeyColor("EFFECT_UPDATE_ATTACK", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_ATTACK", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_ATTACK_FINAL", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_BASE_ATTACK", Color.Khaki);
            ChangeKeyColor("EFFECT_UPDATE_DEFENSE", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_DEFENSE", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_DEFENSE_FINAL", Color.Khaki);
            ChangeKeyColor("EFFECT_SET_BASE_DEFENSE", Color.Khaki);
            ChangeKeyColor("EFFECT_REVERSE_UPDATE", Color.Khaki);


            ChangeKeyColor("EFFECT_SWAP_AD", Color.Khaki);
            ChangeKeyColor("EFFECT_SWAP_BASE_AD", Color.Khaki);
            ChangeKeyColor("EFFECT_ADD_CODE", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_CODE", Color.Khaki);
            ChangeKeyColor("EFFECT_ADD_TYPE", Color.Khaki);
            ChangeKeyColor("EFFECT_REMOVE_TYPE", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_TYPE", Color.Khaki);
            ChangeKeyColor("EFFECT_ADD_RACE	", Color.Khaki);
            ChangeKeyColor("EFFECT_REMOVE_RACE", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_RACE", Color.Khaki);
            ChangeKeyColor("EFFECT_ADD_ATTRIBUTE", Color.Khaki);
            ChangeKeyColor("EFFECT_REMOVE_ATTRIBUTE", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_ATTRIBUTE", Color.Khaki);
            ChangeKeyColor("EFFECT_UPDATE_LEVEL", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_LEVEL", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_LEVEL_FINAL", Color.Khaki);
            ChangeKeyColor("EFFECT_UPDATE_RANK", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_RANK", Color.Khaki);
            ChangeKeyColor("EFFECT_CHANGE_RANK_FINAL", Color.Khaki);
            ChangeKeyColor("EFFECT_SKIP_DP", Color.Khaki);
            ChangeKeyColor("EFFECT_SKIP_SP", Color.Khaki);
            ChangeKeyColor("EFFECT_SKIP_M1", Color.Khaki);
            ChangeKeyColor("EFFECT_SKIP_BP", Color.Khaki);
            ChangeKeyColor("EFFECT_SKIP_M2", Color.Khaki);
            ChangeKeyColor("EVENT_FLIP", Color.Khaki);
            ChangeKeyColor("EVENT_FREE_CHAIN", Color.Khaki);
            ChangeKeyColor("EVENT_REMOVE", Color.Khaki);
            ChangeKeyColor("EVENT_TO_HAND", Color.Khaki);
            ChangeKeyColor("EVENT_TO_DECK", Color.Khaki);
            ChangeKeyColor("EVENT_TO_GRAVE", Color.Khaki);
            ChangeKeyColor("EVENT_CHANGE_POS", Color.Khaki);
            ChangeKeyColor("EVENT_RELEASE", Color.Khaki);
            ChangeKeyColor("EVENT_DISCARD", Color.Khaki);
            ChangeKeyColor("EVENT_LEAVE_FIELD", Color.Khaki);
            ChangeKeyColor("EVENT_CHAIN_SOLVING", Color.Khaki);
            ChangeKeyColor("EVENT_CHAIN_SOLVED", Color.Khaki);
            ChangeKeyColor("EVENT_CHAIN_DISABLED", Color.Khaki);
            ChangeKeyColor("EVENT_CHAINING", Color.Khaki);
            ChangeKeyColor("EVENT_BECOME_TARGET", Color.Khaki);
            ChangeKeyColor("EVENT_DESTROY", Color.Khaki);
            ChangeKeyColor("EVENT_DESTROYED", Color.Khaki);
            ChangeKeyColor("EVENT_MOVE", Color.Khaki);
            ChangeKeyColor("EVENT_ADJUST", Color.Khaki);
            ChangeKeyColor("EVENT_SUMMON_SUCCESS", Color.Khaki);
            ChangeKeyColor("EVENT_FLIP_SUMMON_SUCCESS", Color.Khaki);
            ChangeKeyColor("EVENT_SPSUMMON_SUCCESS", Color.Khaki);
            ChangeKeyColor("EVENT_SUMMON", Color.Khaki);
            ChangeKeyColor("EVENT_BE_MATERIAL", Color.Khaki);
            ChangeKeyColor("EVENT_DRAW", Color.Khaki);
            ChangeKeyColor("EVENT_DAMAGE", Color.Khaki);
            ChangeKeyColor("EVENT_RECOVER", Color.Khaki);
            ChangeKeyColor("EVENT_PREDRAW", Color.Khaki);
            ChangeKeyColor("EVENT_CONTROL_CHANGED", Color.Khaki);
            ChangeKeyColor("EVENT_ATTACK_ANNOUNCE", Color.Khaki);
            ChangeKeyColor("EVENT_BE_BATTLE_TARGET", Color.Khaki);
            ChangeKeyColor("EVENT_BATTLE_START", Color.Khaki);
            ChangeKeyColor("EVENT_BATTLE_CONFIRM", Color.Khaki);
            ChangeKeyColor("EVENT_PRE_DAMAGE_CALCULATE", Color.Khaki);
            ChangeKeyColor("EVENT_PRE_BATTLE_DAMAGE	", Color.Khaki);
            ChangeKeyColor("EVENT_BATTLED", Color.Khaki);
            ChangeKeyColor("EVENT_BATTLE_DESTROYING", Color.Khaki);
            ChangeKeyColor("EVENT_BATTLE_DESTROYED", Color.Khaki);
            ChangeKeyColor("EVENT_DAMAGE_STEP_END", Color.Khaki);
            ChangeKeyColor("EVENT_ATTACK_DISABLED", Color.Khaki);
            ChangeKeyColor("EVENT_TURN_END", Color.Khaki);
            ChangeKeyColor("EVENT_PHASE", Color.Khaki);
            ChangeKeyColor("EVENT_PHASE_START", Color.Khaki);
            ChangeKeyColor("CATEGORY_DESTROY", Color.Khaki);
            ChangeKeyColor("CATEGORY_RELEASE", Color.Khaki);
            ChangeKeyColor("CATEGORY_REMOVE", Color.Khaki);
            ChangeKeyColor("CATEGORY_TOHAND", Color.Khaki);
            ChangeKeyColor("CATEGORY_TODECK", Color.Khaki);
            ChangeKeyColor("CATEGORY_TOGRAVE", Color.Khaki);
            ChangeKeyColor("CATEGORY_DECKDES", Color.Khaki);
            ChangeKeyColor("CATEGORY_HANDES", Color.Khaki);
            ChangeKeyColor("CATEGORY_SUMMON", Color.Khaki);
            ChangeKeyColor("CATEGORY_SPECIAL_SUMMON", Color.Khaki);
            ChangeKeyColor("CATEGORY_TOKEN", Color.Khaki);
            ChangeKeyColor("CATEGORY_GRAVE_ACTION", Color.Khaki);
            ChangeKeyColor("CATEGORY_POSITION", Color.Khaki);
            ChangeKeyColor("CATEGORY_CONTROL", Color.Khaki);
            ChangeKeyColor("CATEGORY_DISABLE", Color.Khaki);
            ChangeKeyColor("CATEGORY_DISABLE_SUMMON", Color.Khaki);
            ChangeKeyColor("CATEGORY_DRAW", Color.Khaki);
            ChangeKeyColor("CATEGORY_SEARCH", Color.Khaki);
            ChangeKeyColor("CATEGORY_EQUIP", Color.Khaki);
            ChangeKeyColor("CATEGORY_DAMAGE", Color.Khaki);
            ChangeKeyColor("CATEGORY_RECOVER", Color.Khaki);
            ChangeKeyColor("CATEGORY_ATKCHANGE", Color.Khaki);
            ChangeKeyColor("CATEGORY_DEFCHANGE", Color.Khaki);
            ChangeKeyColor("CATEGORY_COUNTER", Color.Khaki);
            ChangeKeyColor("CATEGORY_COIN", Color.Khaki);
            ChangeKeyColor("CATEGORY_DICE", Color.Khaki);
            ChangeKeyColor("CATEGORY_LEAVE_GRAVE", Color.Khaki);
            ChangeKeyColor("CATEGORY_LVCHANGE", Color.Khaki);
            ChangeKeyColor("CATEGORY_NEGATE", Color.Khaki);
            ChangeKeyColor("CATEGORY_ANNOUNCE", Color.Khaki);
            ChangeKeyColor("CATEGORY_FUSION_SUMMON", Color.Khaki);
            ChangeKeyColor("CATEGORY_TOEXTRA", Color.Khaki);
            ChangeKeyColor("TYPE_MONSTER", Color.Khaki);
            ChangeKeyColor("TYPE_SPELL", Color.Khaki);
            ChangeKeyColor("TYPE_TRAP", Color.Khaki);
            ChangeKeyColor("TYPE_NORMAL", Color.Khaki);
            ChangeKeyColor("TYPE_EFFECT", Color.Khaki);
            ChangeKeyColor("TYPE_FUSION", Color.Khaki);
            ChangeKeyColor("TYPE_RITUAL", Color.Khaki);
            ChangeKeyColor("TYPE_TRAPMONSTER", Color.Khaki);
            ChangeKeyColor("TYPE_SPIRIT", Color.Khaki);
            ChangeKeyColor("TYPE_UNION", Color.Khaki);
            ChangeKeyColor("TYPE_SYNCHRO", Color.Khaki);
            ChangeKeyColor("TYPE_TUNER", Color.Khaki);
            ChangeKeyColor("TYPE_TOKEN", Color.Khaki);
            ChangeKeyColor("TYPE_QUICKPLAY", Color.Khaki);
            ChangeKeyColor("TYPE_CONTINUOUS", Color.Khaki);
            ChangeKeyColor("TYPE_EQUIP", Color.Khaki);
            ChangeKeyColor("TYPE_FIELD", Color.Khaki);
            ChangeKeyColor("TYPE_FLIP", Color.Khaki);
            ChangeKeyColor("TYPE_TOON", Color.Khaki);
            ChangeKeyColor("TYPE_XYZ", Color.Khaki);
            ChangeKeyColor("TYPE_PENDULUM", Color.Khaki);
            ChangeKeyColor("TYPE_SPSUMMON", Color.Khaki);
            ChangeKeyColor("ATTRIBUTE_EARTH", Color.Khaki);
            ChangeKeyColor("ATTRIBUTE_WATER", Color.Khaki);
            ChangeKeyColor("ATTRIBUTE_FIRE", Color.Khaki);
            ChangeKeyColor("ATTRIBUTE_WIND", Color.Khaki);
            ChangeKeyColor("ATTRIBUTE_LIGHT", Color.Khaki);
            ChangeKeyColor("ATTRIBUTE_DARK", Color.Khaki);
            ChangeKeyColor("ATTRIBUTE_DIVINE", Color.Khaki);
            ChangeKeyColor("RACE_WARRIOR", Color.Khaki);
            ChangeKeyColor("RACE_SPELLCASTER", Color.Khaki);
            ChangeKeyColor("RACE_FAIRY", Color.Khaki);
            ChangeKeyColor("RACE_FIEND", Color.Khaki);
            ChangeKeyColor("RACE_ZOMBIE", Color.Khaki);
            ChangeKeyColor("RACE_MACHINE", Color.Khaki);
            ChangeKeyColor("RACE_AQUA", Color.Khaki);
            ChangeKeyColor("RACE_PYRO", Color.Khaki);
            ChangeKeyColor("RACE_ROCK", Color.Khaki);
            ChangeKeyColor("RACE_WINDBEAST", Color.Khaki);
            ChangeKeyColor("RACE_PLANT", Color.Khaki);
            ChangeKeyColor("RACE_INSECT", Color.Khaki);
            ChangeKeyColor("RACE_THUNDER", Color.Khaki);
            ChangeKeyColor("RACE_DRAGON", Color.Khaki);
            ChangeKeyColor("RACE_BEAST", Color.Khaki);
            ChangeKeyColor("RACE_BEASTWARRIOR", Color.Khaki);
            ChangeKeyColor("RACE_DINOSAUR", Color.Khaki);
            ChangeKeyColor("RACE_FISH", Color.Khaki);
            ChangeKeyColor("RACE_SEASERPENT", Color.Khaki);
            ChangeKeyColor("RACE_REPTILE", Color.Khaki);
            ChangeKeyColor("RACE_PSYCHO", Color.Khaki);
            ChangeKeyColor("RACE_DIVINE", Color.Khaki);
            ChangeKeyColor("RACE_CREATORGOD", Color.Khaki);
            ChangeKeyColor("REASON_COST", Color.Khaki);
        }
        #endregion
        //窗口加载时为文本框文件设置对应的字体和颜色
        private void Form4_Load(object sender, EventArgs e)
        {
            ChangeFont();
            ChangeColor();
        }
    }
}
