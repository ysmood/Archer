/*
Navicat MySQL Data Transfer

Source Server         : MySQL
Source Server Version : 50516
Source Host           : localhost:3306
Source Database       : plus_game

Target Server Type    : MYSQL
Target Server Version : 50516
File Encoding         : 65001

Date: 2011-10-31 14:42:21
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `game`
-- ----------------------------
DROP TABLE IF EXISTS `game`;
CREATE TABLE `game` (
  `id` char(32) CHARACTER SET ascii NOT NULL,
  `p` int(1) NOT NULL DEFAULT '0' COMMENT 'who''s the curren player to act',
  `num_0` int(1) NOT NULL DEFAULT '1',
  `num_1` int(1) NOT NULL DEFAULT '1',
  `num_2` int(1) NOT NULL DEFAULT '1',
  `num_3` int(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of game
-- ----------------------------
INSERT INTO `game` VALUES ('test', '0', '1', '1', '1', '1');
